    [CustomEditor(typeof(Control))]
    public class ControlEditor : Editor
    {
        private SerializedProperty _isControl;
        private SerializedProperty rigidbody;
        private Control control;
    
        // calle when the object gains focus
        private void OnEnable()
        {
            control = (Control)target;
    
            // link serialized property
            _isControl = serializedObject.FindProperty("isControl");
            rigidbody = serializedObject.FindProperty("rigidbody");
        }
    
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
    
            // load current values into the serialized copy
            serializedObject.Update();
    
            if (!_isControl.boolValue && rigidbody.objectReferenceValue)
            {
                DestroyImmediate(rigidbody.objectReferenceValue);
                rigidbody.objectReferenceValue = null;
            }
            else if (_isControl.boolValue && !rigidbody.objectReferenceValue)
            {
                var rb = control.gameObject.AddComponent<Rigidbody>();
                rigidbody.objectReferenceValue = rb;
            }
    
            // write back changed serialized values to the actual values
            serializedObject.ApplyModifiedProperties();
        }
    }
