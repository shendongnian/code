    public class Example : MonoBehaviour
    {
        //This is Main Camera in the scene
        Camera m_MainCamera;
        //This is the second Camera and is assigned in inspector
        public Camera m_CameraTwo;
        void Start()
        {
            //This gets the Main Camera from the scene
            m_MainCamera = Camera.main;
            //This enables Main Camera
            m_MainCamera.enabled = true;
            //Use this to disable secondary Camera
            m_CameraTwo.enabled = false;
        }
    }
