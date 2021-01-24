    public class ReferenceSetter : MonoBehaviour
    {
        public References references;
        // Reference those in the inspector as usual
        public Camera camera;
        public Transform transform;
        public CharacterController controller;
        private void Awake()
        {
            references.Set(camera, controller, transform);
        }
    }
