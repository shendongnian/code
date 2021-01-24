    public class GameObjectManager : MonoBehaviour
    {
        //Holds instance of GameObjectManager
        public static GameObjectManager instance = null;
        public List<GameObject> allObjects = new List<GameObject>();
    
        void Awake()
        {
            //If this script does not exit already, use this current instance
            if (instance == null)
                instance = this;
    
            //If this script already exit, DESTROY this current instance
            else if (instance != this)
                Destroy(gameObject);
        }
    }
