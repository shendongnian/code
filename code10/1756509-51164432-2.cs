    [CustomEditor(typeof(Settings))]
    class TestEditor : Editor
    {
      public override void OnInspectorGUI()
      {
        if ( target == null ) return;
        var settings = target as Settings;
            GUILayout.Label("Settings", EditorStyles.boldLabel);
            settings.SettingsSO.testMode = EditorGUILayout.Toggle("Test Mode", settings.SettingsSO.testMode);
            settings.SettingsSO.androidUnitID = EditorGUILayout.TextField("Android UnitID", settings.SettingsSO.androidUnitID);
            settings.SettingsSO.iphoneUnitID = EditorGUILayout.TextField("Android UnitID", settings.SettingsSO.iphoneUnitID);
      }
    }
