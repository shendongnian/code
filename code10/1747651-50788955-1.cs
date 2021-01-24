    using UnityEngine;
    using UnityEditor;
    
    [CustomPropertyDrawer(typeof(ControlPoint))]
    public class ControlPointDrawer : PropertyDrawer
    {
      public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
      {
    
        EditorGUI.BeginProperty(position, label, property);
        // position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0; //-= 1;
        var propPos = new Rect(position.x, position.y, position.x + 18, position.height);
        var prop = property.FindPropertyRelative("_smooth");
        // target.smooth = EditorGUI.Toggle(propPos, prop.boolValue);
        EditorGUI.PropertyField(propPos, prop, GUIContent.none);
        propPos = new Rect(position.x + 20, position.y, position.width - 20, position.height);
        prop = property.FindPropertyRelative("_position");
        // target.position = EditorGUI.Vector2Field(propPos, GUIContent.none, prop.vector2Value);
        EditorGUI.PropertyField(propPos, prop, GUIContent.none);
        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
      }
    
      public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
      {
        return EditorGUIUtility.singleLineHeight;
      }
    }
