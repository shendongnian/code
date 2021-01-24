    [CustomEditor(typeof(YourOtherClass))]
    public class YourOtherClassEditor : Editor
    {
        // This will be the serialized "copy" of YourOtherClass.YourList
        private SerializedProperty YourList;
        private ReorderableList YourReorderableList;
    
        private void OnEnable()
        {
            // Step 1 "link" the SerializedProperties to the properties of YourOtherClass
            YourList = serializedObject.FindProperty("YourList");
    
            // Step 2 setup the ReorderableList
            YourReorderableList = new ReorderableList(serializedObject, YourList)
            {
                // Can your objects be dragged an their positions changed within the List?
                draggable = true,
    
                // Can you add elements by pressing the "+" button?
                displayAdd = true,
    
                // Can you remove Elements by pressing the "-" button?
                displayRemove = true,
    
                // Make a header for the list
                drawHeaderCallback = rect =>
                {
                    EditorGUI.LabelField(rect, "This are your Elements");
                },
    
                // Now to the interesting part: Here you setup how elements look like
                drawElementCallback = (rect, index, active, focused) =>
                {
                    // Get the currently to be drawn element from YourList
                    var element = YourList.GetArrayElementAtIndex(index);
    
                    // Get the elements Properties into SerializedProperties
                    var Enum = element.FindPropertyRelative("Enum");
                    var Name = element.FindPropertyRelative("Name");
                    var Step = element.FindPropertyRelative("Step");
                    var Position = element.FindPropertyRelative("Position");
    
                    // Draw the Enum field
                    EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), Enum);
                    // start the next property in the next line
                    rect.y += EditorGUIUtility.singleLineHeight;
    
                    // only show Name field if selected "first"
                    if ((YourClass.YourEnum)Enum.intValue == YourClass.YourEnum.first)
                    {
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), Name);
                        // start the next property in the next line
                        rect.y += EditorGUIUtility.singleLineHeight;
                    }
    
                    // Draw the Step field
                    EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), Step);
                    // start the next property in the next line
                    rect.y += EditorGUIUtility.singleLineHeight;
    
                    // only show Step field if selected "seconds"
                    if ((YourClass.YourEnum)Enum.intValue == YourClass.YourEnum.second)
                    {
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), Position);
                    }
                },
    
                // And since we have more than one line (default) you'll have to configure 
                // how tall your elements are. Luckyly in your example it will always be exactly
                // 3 Lines in each case. If not you would have to change this.
                // In some cases it becomes also more readable if you use one more Line as spacer between the elements
                elementHeight = EditorGUIUtility.singleLineHeight * 3,
    
                //alternatively if you have different heights you would use e.g.
                //elementHeightCallback = index =>
                //{
                //    var element = YourList.GetArrayElementAtIndex(index);
                //    var Enum = element.FindPropertyRelative("Enum");
    
                //    switch ((YourClass.YourEnum)Enum.intValue)
                //    {
                //        case YourClass.YourEnum.first:
                //            return EditorGUIUtility.singleLineHeight * 3;
    
                //        case YourClass.YourEnum.second:
                //            return EditorGUIUtility.singleLineHeight * 5;
    
                //            default:
                //                return EditorGUIUtility.singleLineHeight;
                //    }
                //}
    
                // optional: Set default Values when adding a new element
                // (otherwise the values of the last list item will be copied)
                onAddCallback = list =>
                {
                    // The new index will be the current List size ()before adding
                    var index = list.serializedProperty.arraySize;
                    // Since this method overwrites the usual adding, we have to do it manually:
                    // Simply counting up the array size will automatically add an element
                    list.serializedProperty.arraySize++;
                    list.index = index;
                    var element = list.serializedProperty.GetArrayElementAtIndex(index);
                    // again link the properties of the element in SerializedProperties
                    var Enum = element.FindPropertyRelative("Enum");
                    var Name = element.FindPropertyRelative("Name");
                    var Step = element.FindPropertyRelative("Step");
                    var Position = element.FindPropertyRelative("Position");
                    // and set default values
                    Enum.intValue = (int) YourClass.YourEnum.first;
                    Name.stringValue = "";
                    Step.intValue = 0;
                    Position.vector3Value = Vector3.zero;
                }
            };
        }
    
        public override void OnInspectorGUI()
        {
            // copy the values of the real Class to the linked SerializedProperties
            serializedObject.Update();
    
            // print the reorderable list
            YourReorderableList.DoLayoutList();
    
            // apply the changed SerializedProperties values to the real class
            serializedObject.ApplyModifiedProperties();
        }
    }
