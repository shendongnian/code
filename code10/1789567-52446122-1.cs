    public class SomeGameObject : MonoBehaviour {
    
      public APIClient api/*=new APIClient()*/;
    
      void Start () {
        api= new APIClient();//its better to do it here in case its constructor does dark magic
        StartCoroutine (api.QueryCall( (bool success) => {
            if (success)
              Debug.Log( "success!");
            else
              Debug.Log( "fail!");
        }))
      }
    }
