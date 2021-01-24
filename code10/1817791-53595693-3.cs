    public static class Data
    {
        public static List<GameObject> ObjectsInScene = new List<GameObject>();
    
        public static void AddObject(GameObject obj)
        {
            ObjectsInScene.Add(obj);
        }
    }
    
    public class Setup3D : MonoBehaviour
    {
        public GameObject prefab;
    
        void Start()
        {
            // Adding objects to your list
            GameObject objInstance = Instantiate(prefab);
            Data.AddObject(objInstance);
    
            // cycling through the list
            foreach (GameObject obj in Data.ObjectsInScene)
            {
                Instantiate(obj);
            }
        }
    }
