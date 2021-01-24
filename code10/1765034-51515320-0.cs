    public class Trigger1 : MonoBehaviour {
     public Trigger2 trigger2;
     void Start()
      {
        trigger2.enabled=false;
      }
      private void OnTriggerEnter(Collider other)
      {
         trigger2.enabled=true;
      }
   }
    public class Trigger2 : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
     if (enabled)
        {do something else}
    }
