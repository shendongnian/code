    public static InputField GetInputField
    {
      get
      {
        return EditorUtility.InstanceIDToObject(EditorPrefs.GetInt("InputFieldId"));
      }
      set
      {
        EditorPrefs.GetInt("InputFieldId", value.GetInstanceId());
      }
    }
