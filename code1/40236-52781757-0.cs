    using UnityEngine;
    
    public class ExampleScript : MonoBehaviour
    {
        void Start()
        {
            // Prints 10
            Debug.Log(Mathf.RoundToInt(10.0f));
            // Prints 10
            Debug.Log(Mathf.RoundToInt(10.2f));
            // Prints 11
            Debug.Log(Mathf.RoundToInt(10.7f));
            // Prints 10
            Debug.Log(Mathf.RoundToInt(10.5f));
            // Prints 12
            Debug.Log(Mathf.RoundToInt(11.5f));
    
            // Prints -10
            Debug.Log(Mathf.RoundToInt(-10.0f));
            // Prints -10
            Debug.Log(Mathf.RoundToInt(-10.2f));
            // Prints -11
            Debug.Log(Mathf.RoundToInt(-10.7f));
            // Prints -10
            Debug.Log(Mathf.RoundToInt(-10.5f));
            // Prints -12
            Debug.Log(Mathf.RoundToInt(-11.5f));
        }
    }
