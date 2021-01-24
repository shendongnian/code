    using UnityEngine;
    using System.Collections;
    
    public class WaitForSecondsExample : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(Example());
        }
    
        IEnumerator Example()
        {     
            yield return new WaitForSeconds(5);
        }
    }
