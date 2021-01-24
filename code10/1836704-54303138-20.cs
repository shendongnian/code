    public class ExampleScript : MonoBehaviour
    {
        [SerializeField] private List<EventDelayPair> EventDelayPairs;
    
        private void Start()
        {
            foreach (var eventDelayPair in EventDelayPairs)
            {
                StartCoroutine(InvokeDelayed(eventDelayPair.unityEvent, eventDelayPair.Delay));
            }
        }
    
        private IEnumerator InvokeDelayed(UnityEvent unityEvent, float delay)
        {
            yield return new WaitForSeconds(delay);
    
            unityEvent.Invoke();
        }
    
        [Serializable]
        private class EventDelayPair
        {
            public UnityEvent unityEvent;
            public float Delay;
        }
    }
    
    [CustomEditor(typeof(ExampleScript))]
    public class ExampleInspector : Editor
    {
        private SerializedProperty EventDelayPairs;
        private ReorderableList list;
    
        private ExampleScript _exampleScript;
    
        private void OnEnable()
        {
            _exampleScript = (ExampleScript)target;
    
            EventDelayPairs = serializedObject.FindProperty("EventDelayPairs");
    
            list = new ReorderableList(serializedObject, EventDelayPairs)
            {
                draggable = true,
                displayAdd = true,
                displayRemove = true,
                drawHeaderCallback = rect =>
                {
                    EditorGUI.LabelField(rect, "DelayedEvents");
                },
                drawElementCallback = (rect, index, sel, act) =>
                {
                    var element = EventDelayPairs.GetArrayElementAtIndex(index);
    
                    var unityEvent = element.FindPropertyRelative("unityEvent");
                    var delay = element.FindPropertyRelative("Delay");
    
    
                    EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), delay);
    
                    rect.y += EditorGUIUtility.singleLineHeight;
    
                    EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUI.GetPropertyHeight(unityEvent)), unityEvent);
    
    
                },
                elementHeightCallback = index =>
                {
                    var element = EventDelayPairs.GetArrayElementAtIndex(index);
    
                    var unityEvent = element.FindPropertyRelative("unityEvent");
    
                    var height = EditorGUI.GetPropertyHeight(unityEvent) + EditorGUIUtility.singleLineHeight;
    
                    return height;
                }
            };
        }
    
        public override void OnInspectorGUI()
        {
            DrawScriptField();
    
            serializedObject.Update();
    
            list.DoLayoutList();
    
            serializedObject.ApplyModifiedProperties();
        }
    
        private void DrawScriptField()
        {
            // Disable editing
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour(_exampleScript), typeof(ExampleScript), false);
            EditorGUI.EndDisabledGroup();
    
            EditorGUILayout.Space();
        }
    }
