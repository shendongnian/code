    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;
    
    [CustomEditor(typeof(CircleSpawn))]
    public class CircleSpawnEditor : Editor
    {
        private CircleSpawn targetObj;
        private static float previousRadius;
        private static int previousNumOfItems;
        private static float previousAngleIncrement;
    
        private static float angleIncrement = 0;
    
        public override void OnInspectorGUI()
        {
            var tar = (CircleSpawn)target;
            targetObj = tar;
    
            makeSlider("Radius", tar.radius, 0f, 10, 24, UpdateType.RADIUS);
    
            makeSlider("Number of Items", tar.numOfItems, 0f, 100, 24, UpdateType.RESPAWN);
    
            makeSlider("Angle", angleIncrement, 0f, 360, 24, UpdateType.ANGLE);
    
            //set its values
            tar.radius = EditorGUILayout.FloatField("Radius:", tar.radius);
            tar.numOfItems = EditorGUILayout.IntField("Number of Items:", tar.numOfItems);
            angleIncrement = EditorGUILayout.FloatField("Angle:", angleIncrement);
    
            tar.clonedObject = (GameObject)EditorGUILayout.ObjectField(tar.clonedObject,
                       typeof(GameObject), true);
    
            //Inspector button for creating the objects in the Editor
            if (GUILayout.Button("Create"))
            {
                RespawnNumOfItems();
            }
        }
    
        void makeSlider(string label, float value, float min, float max, int space, UpdateType updateType)
        {
            GUILayout.Space(2);
            GUILayout.Label(label);
            if (updateType == UpdateType.RADIUS)
                targetObj.radius = GUILayout.HorizontalSlider(targetObj.radius, min, max);
            if (updateType == UpdateType.RESPAWN)
                targetObj.numOfItems = (int)GUILayout.HorizontalSlider(targetObj.numOfItems, min, max);
            if (updateType == UpdateType.ANGLE)
                angleIncrement = GUILayout.HorizontalSlider(angleIncrement, min, max);
    
            GUILayout.BeginHorizontal();
            var defaultAlignment3 = GUI.skin.label.alignment;
            GUILayout.Label(min.ToString());
            GUI.skin.label.alignment = TextAnchor.UpperRight;
            GUILayout.Label(max.ToString());
            GUI.skin.label.alignment = defaultAlignment3;
            GUILayout.EndHorizontal();
            GUILayout.Space(space);
        }
    
        void OnEnable()
        {
            EditorApplication.update += Update;
        }
        void OnDisable()
        {
            EditorApplication.update -= Update;
        }
    
        void Update()
        {
            if (targetObj != null)
            {
                float clampedNewRadius = Mathf.Clamp(targetObj.radius, 0f, float.MaxValue);
    
                //Check if Radius changed
                if (RadiusChanged())
                {
                    //Debug.Log("Radius Changed: " + targetObj.radius);
                    previousRadius = clampedNewRadius;
                    targetObj.radius = clampedNewRadius;
                    UpdateRadius();
                }
    
    
                int clampedNewNumOfItems = Mathf.Clamp(targetObj.numOfItems, 0, int.MaxValue);
    
                //Check if NumOfItems changed
                if (NumOfItemsChanged())
                {
                    //Debug.Log("NumOfItems Changed: " + previousNumOfItems);
                    previousNumOfItems = clampedNewNumOfItems;
                    targetObj.numOfItems = clampedNewNumOfItems;
                    RespawnNumOfItems();
                }
    
                float clampedAngle = Mathf.Clamp(angleIncrement, 0, int.MaxValue);
    
                //Check if Angle changed
                if (AngleChanged())
                {
                    //Debug.Log("Angle Changed: " + previousAngleIncrement);
                    UpdateAngle();
                    previousAngleIncrement = clampedAngle;
                    angleIncrement = clampedAngle;
                }
            }
        }
    
        private void UpdateAngle()
        {
            UpdateTransform(UpdateType.ANGLE);
        }
    
        private void RespawnNumOfItems()
        {
            if (targetObj.spawnedObjects == null)
                targetObj.spawnedObjects = new List<GameObject>();
    
            //clean up old objects
            if (targetObj.spawnedObjects != null)
            {
                // Debug.LogWarning("Destroyed");
                foreach (var ob in targetObj.spawnedObjects)
                {
                    DestroyImmediate(ob);
                }
            }
    
            //Clear list
            targetObj.spawnedObjects.Clear();
            //Debug.LogWarning("Cleared List");
    
            UpdateTransform(UpdateType.RESPAWN);
        }
    
        private void UpdateRadius()
        {
            UpdateTransform(UpdateType.RADIUS);
        }
    
        void UpdateTransform(UpdateType updateType)
        {
            float angleBetween = 360.0f / targetObj.numOfItems;
            float angle = 0;
    
            if (targetObj != null)
    
                for (int i = 0; i < targetObj.numOfItems; i++)
                {
                    //For each object, find a rotation and position
                    var rot = Quaternion.Euler(0, 0, angle);
                    var localPos = rot * Vector3.right * targetObj.radius;
    
                    //Debug.LogWarning("Updated");
    
                    if (updateType == UpdateType.RADIUS)
                    {
                        //Make sure that loop is within range
                        if (targetObj.spawnedObjects != null && i < targetObj.spawnedObjects.Count)
                        {
                            GameObject obj = targetObj.spawnedObjects[i];
                            if (obj != null)
                            {
                                Transform trans = obj.transform;
                                trans.position = targetObj.transform.position + localPos;
                                trans.rotation = rot;
                            }
                        }
                    }
                    else if (updateType == UpdateType.RESPAWN)
                    {
                        if (targetObj.clonedObject != null)
                        {
                            GameObject objToAdd = Instantiate(targetObj.clonedObject, Vector3.zero, Quaternion.identity);
                            objToAdd.transform.position = targetObj.transform.position + localPos;
                            objToAdd.transform.rotation = rot;
                            targetObj.spawnedObjects.Add(objToAdd);
                        }
                        else
                        {
                            // Debug.LogError("Please assign the clonedObject prefab in the Scene");
                        }
                    }
                    else if (updateType == UpdateType.ANGLE)
                    {
                        //Make sure that loop is within range
                        if (targetObj.spawnedObjects != null && i < targetObj.spawnedObjects.Count)
                        {
                            GameObject obj = targetObj.spawnedObjects[i];
                            if (obj != null)
                            {
                                Transform trans = obj.transform;
                                Vector3 tagetPoint = targetObj.transform.position;
                                //Decide if we should rotate left or rigt
                                if (previousAngleIncrement > angleIncrement)
                                    trans.RotateAround(tagetPoint, Vector3.forward, angleIncrement);
                                else
                                    trans.RotateAround(tagetPoint, -Vector3.forward, angleIncrement);
                            }
    
                        }
                    }
                    if (updateType != UpdateType.ANGLE)
                        angle += angleBetween;
                }
    
            //Uncomment to test auto angle rotation over frame
            //testAngle();
        }
    
        void testAngle()
        {
            float speed = 0.005f;
            angleIncrement = (float)EditorApplication.timeSinceStartup * speed;
        }
    
        private bool RadiusChanged()
        {
            bool changed = !Mathf.Approximately(targetObj.radius, previousRadius)
                && !(targetObj.radius < 0);
            return changed;
        }
    
        private bool NumOfItemsChanged()
        {
            bool changed = (targetObj.numOfItems != previousNumOfItems)
                && !(targetObj.numOfItems < 0);
            return changed;
        }
    
    
        private bool AngleChanged()
        {
            bool changed = !Mathf.Approximately(angleIncrement, previousAngleIncrement)
               && !(angleIncrement < 0);
            return changed;
        }
    
        public enum UpdateType
        {
            RADIUS, RESPAWN, ANGLE
        }
    }
 
