    SerializedProperty ClipArray;
    // I would always do these only once ;)
    private void OnEnable()
    {
        ClipArray = serializedObject.FindProperty("ClipArray");
    }
    private void OnInspectorGUI ()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(ClipArray, true);
        serializedObject.ApplyModifiedProperties();
    }
