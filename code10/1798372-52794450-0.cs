    public class RoEditorWindow : EditorWindow
    {
        private static RoEditorWindow win;
        EditorApplication.CallbackFunction appCb;
    
        [MenuItem("Window/Ro Editor Window %g")]
        static void St()
        {
            if (!win)
            {
                win = EditorWindow.GetWindow<RoEditorWindow>();
            }
            else
            {
    
                Debug.Log("Run focus");
                win.Focus();
            }
        }
    
        void OnEnable()
        {
            EnableInputEvent();
        }
    
        void OnDisable()
        {
            DisableInputEvent();
        }
    
        void EnableInputEvent()
        {
            FieldInfo fieldInfo = typeof(EditorApplication).GetField("globalEventHandler", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            appCb = (EditorApplication.CallbackFunction)fieldInfo.GetValue(null);
            appCb += OnEditorKeyPress;
            fieldInfo.SetValue(null, appCb);
        }
    
        void DisableInputEvent()
        {
            FieldInfo fieldInfo = typeof(EditorApplication).GetField("globalEventHandler", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            appCb -= OnEditorKeyPress;
            fieldInfo.SetValue(null, appCb);
        }
        private void OnEditorKeyPress()
        {
            var ev = Event.current;
            if (ev.control && ev.type == EventType.KeyDown && ev.keyCode == KeyCode.G)
            {
                Debug.Log("key is pressed");
            }
        }
    }
