    private SerializedProperty _value;
    private void OnEnable()
    {
        // Link the SerializedProperty to the variable 
        _value = serializedObject.FindProperty("value");
    }
    public override OnInspectorGUI()
    {
        // fetch current values from the target
        serializedObject.Update();
        EditorGUI.PropertyField(textFieldRect, _value);
        // Apply values to the target
        serializedObject.ApplyModifiedValues();
    }
