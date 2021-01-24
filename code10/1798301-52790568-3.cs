    public class applySize : MonoBehaviour 
    {
        private void Apply()
        {
            // Get the main camera position
            var cameraPosition = Camera.main.transform.position;
            // This makes the parent GameObject "fit the screen size"
            var height = 2 * Camera.main.orthographicSize;
            var width = height * Camera.main.aspect;
            transform.localScale = new Vector3(width, height,1);
            transform.position = cameraPosition - new Vector3(0,height*.375f, cameraPosition.z);
            // Since the 4 images are childs of the parent GameObject there is no need
            // place or scale them separate. It is all done with placing this parent object
        }
        private void Start()
        {
            Apply();
        }
    }
