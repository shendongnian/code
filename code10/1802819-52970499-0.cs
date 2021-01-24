    public class MyClass : MonoBehaviour
    {
        [SerializeField]
        GameObject myPrefab;
        
        void Start()
        {
             GameObject g = null;
             for(int i = 0; i < 5; i++)
             {
                 g = GameObject.Instantiate(myPrefab);
                 g.name = "MyPrefab_" + (i+i);
             }
        }
    }
