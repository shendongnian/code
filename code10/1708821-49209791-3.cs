    [CustomPropertyDrawer(typeof(TestAttribute))]
    public class TestDecorator : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var lineCount = ((TestAttribute) attribute).maxlineCount + 1;
            return (base.GetPropertyHeight(property, label) + EditorGUIUtility.standardVerticalSpacing) * lineCount;
        }
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var ta = (TestAttribute) attribute;
    
            position.height = EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(position, property, label);
    
            position.height *= ta.maxlineCount;
            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            position = EditorGUI.PrefixLabel(position, new GUIContent("About"));
    
            EditorGUI.TextArea(position, ta.content, EditorStyles.wordWrappedLabel);
        }
    }
