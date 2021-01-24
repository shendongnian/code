    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data", order = 1)]
    public class References : ScriptableObject
    {
        public Camera mainCamera;
        public CharacterController controller;
        public Transform transform;
        // fix for the generic methods
        // a bit dirty maybe but should work
        public void Set(Component component)
        {
            if(component.GetType() == typeof(Camera))
            {
                mainCamera = (Camera) component;
            } 
            else if(component.GetType() == typeof(CharacterController))
            {
                controller = (CharacterController) component;
            }
            else if(component.GetType() == typeof(Transform))
            {
                transform = (Transform) component;
            }
        }
        public void Set(Camera camera)
        {
            mainCamera = camera;
        }
        public void Set(CharacterController characterController )
        {
            controller = characterController ;
        }
        public void Set(Transform characterTransform)
        {
            transform = characterTransform;
        }
        // or simply all at once
        public void Set(Camera camera, CharacterController characterController, Transform characterTransform)
        {
            mainCamera = camera;
            controller = characterController;
            transform = characterTransform;
        }
        // etc
    }
