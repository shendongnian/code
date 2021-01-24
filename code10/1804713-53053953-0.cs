    public class MyMono : MonoBehaviour
    {  
        public TextAsset json;
    
        void Start() {
            Debug.Log(json.text);
        }
