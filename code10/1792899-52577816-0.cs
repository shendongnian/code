    public class HumanEntity : MonoBehaviour 
    {
    
         public static int HumanCount { get; private set; }
         void Awake(){ HumanCount++; }
         void OnDestroy(){ HumanCount--; }
         public static void ResetCounter(){ HumanCount = 0; }
    }
