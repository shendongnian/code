    using UnityEditor;
    using UnityEngine;
    
    [CustomEditor(typeof(Transform), true, isFallback = false)]
    public class TransformEditor : Editor
    {
        private SerializedProperty position;
        private SerializedProperty rotation;
        private SerializedProperty scale;
    
        private void OnEnable()
        {
            position = serializedObject.FindProperty("m_LocalPosition");
            rotation = serializedObject.FindProperty("m_LocalRotation");
            scale = serializedObject.FindProperty("m_LocalScale");
        }
    
        private void OnSceneGUI()
        {
            serializedObject.Update();
    
            position.vector3Value = Handles.PositionHandle(position.vector3Value, Quaternion.identity);
            rotation.quaternionValue = Handles.RotationHandle(rotation.quaternionValue, position.vector3Value);
            scale.vector3Value = Handles.ScaleHandle(scale.vector3Value, position.vector3Value, rotation.quaternionValue, 1);
    
            serializedObject.ApplyModifiedProperties();
        }
    }
