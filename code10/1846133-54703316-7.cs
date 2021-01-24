    using UnityEditor;
    using UnityEngine;
    
    [CustomEditor(typeof(Control))]
    public class ControlEditor : Editor
    {
        private Control control;
    
        // calle when the object gains focus
        private void OnEnable()
        {
            control = (Control)target;
        }
    
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (!control.isControl && control.rigidbody)
            {
                control.ToControl();
                Repaint();
            }
            else if (control.isControl && !control.rigidbody)
            {
                control.ToControl();
                Repaint();
            }
        }
    }
