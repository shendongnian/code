     public class Tool : EditorWindow
     {
          public InputField inputField;
          // ...
          public void OnGUI()
          {
               inputField = (InputField)EditorGUILayout.ObjectField("Input Field", inputField, typeof(InputField), true);
               // if inputField has nothing currently assigned
               if (inputField == null)
               {
                    // make sure we have and int stored
                    if (ToolReferences.inputFieldId != 0)
                    {
                         inputField = (InputField)EditorUtility.InstanceIDToObject(ToolReferences.inputFieldId);
                    }
                    else // ... prompt the user to assign one
               }
               // if we have an InputField assigned, store ID to int
               else if (inputField != null) ToolReferences.inputFieldId = inputField.GetInstanceID();
               }
           } 
     // ...
     } 
