    [CustomEditor(typeof(Transform))]
    public class TransformEditor : Editor
    {
        SerializedProperty position;
        SerializedProperty rotation;
        SerializedProperty scale;
        
        private void OnEnable()
        {
            position = serializeObject.FindProperty("m_LocalPosition");
            rotation = serializedObject.FindProperty("m_LocalRotation");
            scale = serializedObject.FindProperty("m_LocalScale");
        }
        
        public override void OnSceneGUI()
        {
            serializedObject.Update();
            position.vector3Value = Handles.PositionHandle(position.vector3Value, Quaternion.identity);
            rotation.quaternionValue = RotationHandle(rotation.quaternionValue, position.vector3Value);
            scale.vector3Value = ScaleHandle(scale.vector3Value, position.vector3Value, rotation.quaternionValue, handleSize);
        
            serializedObject.ApplyModifiedProperties();
        }
    }
