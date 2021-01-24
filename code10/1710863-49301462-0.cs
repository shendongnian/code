    using UnityEditor;
    using UnityEngine;
    
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class Some : Editor
    {
        public override void OnInspectorGUI()
    	{
            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
    		DrawPropertiesExcluding(serializedObject, "m_Script");
            if (EditorGUI.EndChangeCheck())
    	        serializedObject.ApplyModifiedProperties();
        }
    }
