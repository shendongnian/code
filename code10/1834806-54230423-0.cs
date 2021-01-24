    [RequireComponent(typeof(Camera))]
    public class CameraSetter : MonoBehaviour
    {
        public MainCamera camAsset;
        private void Awake ()
        {
            camAsset.Camera = GetComponent<Camera>();
        }
    }
