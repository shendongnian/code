    public class HumanEntity : MonoBehaviour 
    {
         public static int HousedHuman { get; private set; }
         public static int HumanCount { get; private set; }
         void Awake() {  HumanCount++;  }
         void OnDestroy()
         { 
             HumanCount--; 
             if(human.HasAHouse == true){ HousedHuman--; }
         }
         public static void ResetCounter() {  HouseHuman = HumanCount = 0; }
    
         void Update () {
            if (human != null)
            {
                Vector3 targetPosition = human.Target.GameObject.transform.position;
                if (transform.position.Equals(targetPosition)) {
                    if (!human.HasAHouse)
                    {
                        HouseHuman++;    // Added
                        human.HasAHouse = true;
                        // Rest of code
                    }
                }
                // Rest of code
            }
        }
    }
