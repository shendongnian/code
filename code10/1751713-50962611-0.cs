    public class YourClass : MonoBehaviour {
    public static YourClass singleton = null;
  
    void Awake()
    {
         DontDestroyOnLoad(this.gameObject);
         if(singleton == null)
         {
             singleton = this;
         } 
    }}
