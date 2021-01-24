    public class YourClass: MonoBehaviour 
    {
        public GameObject yourPrefab;
        public GameObject yourGameObject;
    
        // Use this for initialization
        void Start () 
        {
            
        }
    
        // Update is called once per frame
        void Update () 
        {
           
        }
    
        void InstantiateGO()
        {
            yourGameObject = Instantiate(yourPrefab); // assign the newly instantiated GameObject to yourGameObject 
        }
        void GetGOPosition()
        {
            var x = yourGameObject.position;
            //Do something here
        }
    }
