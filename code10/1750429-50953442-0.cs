     // class ToolReferences
     public static int inputFieldId
		{
			get
			{
     #if UNITY_EDITOR
				return EditorPrefs.GetInt("inputFieldId", 0);
     #else
                return false;
     #endif
			}
			set
			{
     #if UNITY_EDITOR
				EditorPrefs.SetInt("inputFieldId", value);
     #endif
			}
		}
