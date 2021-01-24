    public class ObjectsController : MonoBehaviour
    {
        // Define in which intervals the file should be read/ the scene should be updated
        public float updateInterval;
        // Prefabs or simply objects that are already in the Scene
        public GameObject A;
        public GameObject B;
        public GameObject C;
        /* Etc ... */
        // Here you map the names from your textile to according object in the scene
        private Dictionary<string, GameObject> gameObjects = new Dictionary<string, gameObjects>();
        private void Awake ()
        {
            // if you use Prefabs than instantiate your objects here; otherwise you can skip this step
            var a = Instantiate(A);
            /* Etc... */
            // Fill the dictionary
            gameObjects.Add(nameOfAInFile, a);
            // OR if you use already instantiated references instead
            gameObjects.Add(nameOfAInFile, A);
        }
    }
    private void Start()
    {
        // Start the file reader
        StartCoroutine (ReadFileRepeatedly());
    }
    // Read file in intervals
    private IEnumerator ReadFileRepeatedly ()
    {
        while(true)
        {
            //ToDo Here read the file
            //Maybe even asynchronous?
            // while(!xy.done) yield return null;
            // Now it depends how your textile works but you can run through 
            // the dictionary and decide for each object if you want to show or hide it
            foreach(var kvp in gameObjects)
            {
                bool active = someConditionDependingOnTheFile;
                kvp.value.SetActive(active);
                // And e.g. position it only if active
                if (active)
                {
                    kvp.value.transform.position = positionFromFile;
                }
            }
            // Wait for updateInterval and repeat
            yield return new WaitForSeconds (updateInterval);
        }
    }
