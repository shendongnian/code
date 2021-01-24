    public class LoadFuncCallerScript: MonoBehaviour
    {
        GameObject targetObject;
        public void Start()
        {
             //Find the GameObject you want to de-activate
            targetObject = GameObject.Find("Cube");
            //De-activate it
            targetObject.SetActive(false);
            //Get it's component/script
            YourDeactivatableScript script = targetObject.GetComponent<YourDeactivatableScript>();
            //Start coroutine on the other script with this MonoBehaviour
            StartCoroutine(script.Load());
        }
    }
