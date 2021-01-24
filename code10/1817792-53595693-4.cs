    using System.Collections.Generic;
    using UnityEngine;
    
    public static class Data
    {
        public static List<DataStructure> ObjectsInScene = new List<DataStructure>();
    
        public static void AddObject(GameObject obj)
        {
            ObjectsInScene.Add(new DataStructure
            {
                position = obj.transform.position,
                rotation = obj.transform.rotation,
                scale = obj.transform.localScale
            });
        }
    }
    
    public class DataStructure
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;    
    }
    
    public class Setup3D : MonoBehaviour
    {
        public GameObject prefab;
    
        void Start()
        {
            // Adding objects to your list
            GameObject objInstance = Instantiate(prefab);
            Data.AddObject(objInstance);
    
            // cycling through the list
            foreach (DataStructure obj in Data.ObjectsInScene)
            {
                var instantiated = Instantiate(prefab);
                instantiated.transform.position = obj.position;
                instantiated.transform.rotation = obj.rotation;
                instantiated.transform.localScale = obj.scale;
            }
        }
    }
