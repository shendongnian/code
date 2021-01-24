    public static class Data 
    {
         private static List<GameObject> objectsInScene;
        
         public static List<GameObject> ObjectsInScene
         {
            get 
            {
                if(objectsInScene == null) objectsInScene = new List<GameObject>();
                return objectsInScene;
            }
         }
    
         public static void AddObject(GameObject obj)
         {
             if(objectsInScene == null) objectsInScene = new List<GameObject>();
             objectsInScene.Add(obj);
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
