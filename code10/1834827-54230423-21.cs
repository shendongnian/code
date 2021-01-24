    // This attribute makes this classes messages be executed also in editmode
    // (= also of not in playmode)
    [ExecuteInEditModo]
    
    // Assure there is a Camera component
    [RequireComponent(typeof(Camera))]
    public class CameraSetter : MonoBehaviour
    {
        [SerializeField] private MainCamera mainCameraAsset;
    
        // Called on initialize
        // With [ExecuteInEditModo] also called on recompile
        private void Awake ()
        {
            mainCameraAsset.AddPair(SceneManager.GetActiveScene,  GetComponent<Camera>();
        }
    }
