    [CustomEditor(typeof(CircleSpawn))]
    public class CircleSpawnEditor : Editor
    {
    	public override void OnInspectorGUI ()
    	{
    		var tar = (CircleSpawn)target;    
    		EditorGUILayout.LabelField("Radius"); // Set as required
    		tar.radius = EditorGUILayout.Slider(tar.radius, 0f, 100f);          
    		EditorGUILayout.LabelField("Angle"); // Set as required
    		tar.spin = EditorGUILayout.Slider(tar.spin, 0f, 360f);              
    		EditorGUILayout.LabelField("Number of Items"); // Set as required
    		tar.numOfItems = EditorGUILayout.IntSlider(tar.numOfItems, 0, 36);  
    		EditorGUILayout.LabelField("Object");
    		tar.clonedObject = (GameObject)EditorGUILayout.ObjectField(tar.clonedObject, 
            typeof(GameObject), true);
    
    		float angle, angleBetween = 360.0f / tar.numOfItems;
    
    		if (tar.spawnedObjects == null)
    			tar.spawnedObjects = new List<GameObject>();
    
    		// Solution #1    
    		if (tar.spawnedObjects.Count != tar.numOfItems)
    		{
    			foreach (var ob in tar.spawnedObjects)
    				DestroyImmediate(ob);
    
    			tar.spawnedObjects.Clear();
    			angle = 0f;
    
    			for (int i = 0; i < tar.numOfItems; i++)
    			{
    				var rot = Quaternion.Euler(0f, 0f, tar.spin + angle);
    				var localPos = rot * Vector3.right * tar.radius;    
    				tar.spawnedObjects.Add(Instantiate(tar.clonedObject,
    				tar.transform.position + localPos, rot));
    				angle += angleBetween;
    			}
    		}
    
    		// Solutions #2 & 3    
    		if (!Mathf.Approximately(tar.spin, tar.spinLast) ||
    			!Mathf.Approximately(tar.radius, tar.radiusLast))
    		{
    			tar.spinLast = tar.spin;
    			tar.radiusLast = tar.radius;    
    			angle = 0f;
    
    			for (int i = 0; i < tar.numOfItems; i++)
    			{
    				var rot = Quaternion.Euler(0f, 0f, tar.spin + angle);
    				var localPos = rot * Vector3.right * tar.radius;    
    				tar.spawnedObjects[i].transform.position = 
                    tar.transform.position + localPos;
    				tar.spawnedObjects[i].transform.rotation = rot;
    				angle += angleBetween;
    			}
    		}
    	}
    }
