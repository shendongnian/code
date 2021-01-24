    using UnityEditor;
    using UnityEngine;
    
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class DefaultMonoBehaviourEditor : Editor
    {
        private bool hideScriptField;
    
        private void OnEnable()
        {
            hideScriptField = target.GetType().GetCustomAttributes(typeof(HideScriptField), false).Length > 0;
        }
    
        public override void OnInspectorGUI()
        {
            if (hideScriptField)
            {
                serializedObject.Update();
                EditorGUI.BeginChangeCheck();
                DrawPropertiesExcluding(serializedObject, "m_Script");
                if (EditorGUI.EndChangeCheck())
                    serializedObject.ApplyModifiedProperties();
            }
            else
            {
                base.OnInspectorGUI();
            }
        }
    }
