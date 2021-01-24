    [CustomPropertyDrawer(typeof(ModelSelection))]
    public class ModelSelectionDrawer : PropertyDrawer
    {
        // Lets just say we want the property to have a height of 3 lines
        // one for the label, and one for each dropdown
        // It makes it easier for now to place the dropdowns
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 3;
        }
    
        // Kind of like the Inspectors update method
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Using BeginProperty / EndProperty on the parent property means that
            // prefab override logic works on the entire property.
            EditorGUI.BeginProperty(position, label, property);
    
            // Draw label
            EditorGUI.LabelField(position, label);
            // go to next line
            position.y += EditorGUIUtility.singleLineHeight;
    
            // Don't make child fields be indented
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
    
    
            // first of all link the according variables
            var _manufacturerId = property.FindPropertyRelative("ManufacturerId");
            var _modelId = property.FindPropertyRelative("ModelId");
    
            // You somehow need access to the reference of ManufacturerContainer
            // I will assume here you now how to make it accessable all over your scene 
            // and pretend it is already stored in this variable
    
            // I just create one right here in order to have something to show already
            var container = new ManufacturerContainer
            {
                Manufacturers = new List<Manufacturer>
                {
                    new Manufacturer
                    {
                        Name = "Man_1",
                        Models = new List<Model>
                        {
                            new Model
                            {
                                Name = "Model_A"
                            },
                            new Model
                            {
                                Name = "Model_B"
                            }
                        }
                    },
    
                    new Manufacturer
                    {
                        Name = "Man_2",
                        Models = new List<Model>
                        {
                             new Model
                             {
                                 Name = "Model_C"
                             },
                             new Model
                             {
                                 Name = "Model_D"
                             }
                        }
                    }
                }
            };
    
            // Now you would get the available manufacturers
            var availableManufacturers = container.GetAvailableManufacturers().ToArray();
    
            // Make the dropdown field for manufacturer
            // Get the position for this field
            var field1_rect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            // add a label
            field1_rect = EditorGUI.PrefixLabel(field1_rect, new GUIContent("Manufacturer"));
            position.y += EditorGUIUtility.singleLineHeight;
    
            // get index of currently selected manufacturer
            var currentManIndex = availableManufacturers.ToList().IndexOf(_manufacturerId.stringValue);
            // clamp to minimum 0 (it returns -1 if the string is incorrect/not found in the list)
            currentManIndex = Mathf.Max(currentManIndex, 0);
    
            // problem it returns an int -> index
            // => if you add or delete an item later in middle the XML it breaks
            // you would have to fix this on your own
            var newManIndex = EditorGUI.Popup(field1_rect, currentManIndex, availableManufacturers.ToArray());
    
            // now we have the new index but we have to write back the selected object to the target class
            _manufacturerId.stringValue = availableManufacturers[newManIndex];
    
    
    
            // Now that you have a manufacturer selected you can get and select the model
            var availableModels = container.GetManufacturerByName(_manufacturerId.stringValue).GetAvailableModels().ToArray();
    
            // Make the dropdown field for manufacturer
            // Get the position for this field
            var field2_rect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            // add a label
            field2_rect = EditorGUI.PrefixLabel(field2_rect, new GUIContent("Model"));
            position.y += EditorGUIUtility.singleLineHeight;
    
            // get index of currently selected manufacturer
            var currentModIndex = availableModels.ToList().IndexOf(_modelId.stringValue);
            // also clamp this to minimum 0
            currentModIndex = Mathf.Max(currentModIndex, 0);
    
    
            // problem it returns an int -> index
            // => if you add or delete an item later in middle the XML it breaks
            // you would have to fix this on your own
            var newModIndex = EditorGUI.Popup(field2_rect, currentModIndex, availableModels.ToArray());
    
            // now we have the new index but we have to write back the selected object to the target class
            _modelId.stringValue = availableModels[newModIndex];
    
            // Set indent back to what it was
            EditorGUI.indentLevel = indent;
    
            EditorGUI.EndProperty();
        }
    }
