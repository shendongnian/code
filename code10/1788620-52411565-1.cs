     public class Spawner : MonoBehaviour{
           void Start(){
                 GameObject btn = Instantiate<GameObject>(btnPrefab);
                 btn.GetComponent<Button>().onClick.AddListener(Method);
            }
            void Method(){}
     }
