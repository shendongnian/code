    public override void OnInspectorGUI ()
    {
    	this.serializedObject.Update();
    
    	SerializedProperty items = this.serializedObject.FindProperty("items");
    
    	for (int i = 0; i < items.arraySize; i++)
    	{
    		SerializedProperty item = items.GetArrayElementAtIndex(i);
            EditorGUILayout.BeginHorizontal();
    		EditorGUILayout.LabelField("Item", GUILayout.Width(50));
    		EditorGUILayout.PropertyField(item.FindPropertyRelative("item"), GUIContent.none, GUILayout.Width(170));
    		EditorGUILayout.LabelField("    Quantity", GUILayout.Width(80));
    		EditorGUILayout.IntField(item.FindPropertyRelative("quantity").intValue, GUILayout.Width(50));
    
    		EditorGUILayout.LabelField("", GUILayout.Width(20));
    		GUILayout.Button("Delete Item");
    		EditorGUILayout.EndHorizontal();
    	}
    
    	GUILayout.Button("Add Item");
    }
