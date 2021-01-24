    [CustomEditor(typeof(CircleSpawn))]
    public class CircleSpawnEditor : Editor
    {
    	public override void OnInspectorGUI ()
    	{
    		var spawner = (CircleSpawn)target;
    
    		// Draw object field
    		EditorGUILayout.LabelField("Object");
    		spawner.OriginalObject = (GameObject)EditorGUILayout.ObjectField(
    		spawner.OriginalObject, typeof(GameObject), true);
    		if (!spawner.OriginalObject) return;
    
    		// Store data reference
    		if (!spawner.Data)
    		{
    			spawner.Data = spawner.OriginalObject.GetComponent<SpawnData>();
    			if (!spawner.Data) return;
    		}
    
    		// Draw numeric sliders
    		EditorGUILayout.LabelField("Radius"); // Set as required
    		spawner.Data.Radius = EditorGUILayout.Slider(spawner.Data.Radius, 0f, 100f);
    		EditorGUILayout.LabelField("Angle"); // Set as required
    		spawner.Data.Angle = EditorGUILayout.Slider(spawner.Data.Angle, 0f, 360f);
    		EditorGUILayout.LabelField("Count"); // Set as required
    		spawner.Data.Count = EditorGUILayout.IntSlider(spawner.Data.Count, 0, 36);
    
    		// Restore the original object
    		if (GUILayout.Button("Revert") || !spawner.ActiveObject)
    		{
    			spawner.SetActiveObj(spawner.OriginalObject);
    			spawner.UpdateObjects();
    		}
    
    		// Update objects on Count slider change
    		if (spawner.Data.Count != spawner.Objects.Count)
    			spawner.UpdateObjects();
    
    		// Update transforms on Angle or Radius slider change
    		if (!Mathf.Approximately(spawner.Data.Angle, spawner.Data.LastAngle) ||
    			!Mathf.Approximately(spawner.Data.Radius, spawner.Data.LastRadius))
    		{
    			spawner.Data.LastAngle = spawner.Data.Angle;
    			spawner.Data.LastRadius = spawner.Data.Radius;
    			spawner.UpdateTransforms();
    		}
    	}
    }
