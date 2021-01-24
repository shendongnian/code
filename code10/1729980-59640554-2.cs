    private void OnInspectorGUI ()
    {
        serializedObject.Update();
        ClipArray.isExpanded = EditorGUILayout.Foldout(ClipArray.isExpanded, ClipArray.name);
        if(ClipArray.isExpanded)
        {
            EditorGUI.indentLevel++;
            // The field for item count
            ClipArray.arraySize = EditorGUILayout.IntField("size", ClipArray.arraySize);
            // draw item fields
            for(var i = 0; i< ClipArray.arraySize; i++)
            {
                var item = ClipArray.GetArrayElementAtIndex(i);
                EditorGUILayout.PropertyField(item, new GUIContent($"Element {i}");
            }
            EditorGUI.indentLevel--;
        }
        serializedObject.ApplyModifiedProperties();
    }
