    public class WorldBuilder : MonoBehaviour {
        public static GameObject Play;
        
        public static void Awake()
        {
            Debug.Log("Finding Scene...");
            WorldBuilder.Play = GameObject.Find("PlayScreen");
            Debug.Log(Play);
        } 
    }
