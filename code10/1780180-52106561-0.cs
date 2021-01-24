    public class Test : MonoBehaviour
    {
    
        public Camera MainC;
        public GameObject testc;
    
        // Use this for initialization
        void Start()
        {
            var ui = Object.Instantiate((GameObject)Resources.Load("uit"), Vector2.zero, Quaternion.identity);
            ui.transform.SetParent(GameObject.FindObjectOfType<Canvas>().gameObject.transform, false);
            var uiRT = ui.GetComponent<RectTransform>();
            // Ensure uiRT's pivot and anchors are set to the bottom left preset.
            uiRT.anchorMin = Vector2.zero;
            uiRT.anchorMax = Vector2.zero;
            uiRT.pivot = Vector2.zero;
    
            var vertexs = testc.GetComponent<MeshFilter>().mesh.vertices;
            var trs = testc.GetComponent<Transform>();
            var cdc = new Vector2(GameObject.FindObjectOfType<Canvas>().GetComponent<RectTransform>().sizeDelta.x, GameObject.FindObjectOfType<Canvas>().GetComponent<RectTransform>().sizeDelta.y);
    
            Object.Instantiate((GameObject)Resources.Load("pinksphere"), trs.transform.TransformPoint(vertexs[6]), Quaternion.identity); //bottomright
            Object.Instantiate((GameObject)Resources.Load("pinksphere"), trs.transform.TransformPoint(vertexs[5]), Quaternion.identity); //topleft
    
            var tl = MainC.WorldToViewportPoint(trs.transform.TransformPoint(vertexs[5]));
    
            var offset = new Vector2(0, uiRT.sizeDelta.y);
            var topleft = tl * cdc - offset;
            uiRT.anchoredPosition = topleft;
        }
    }
