    using UnityEngine;
    using System.Collections;
    
     public class collision : MonoBehaviour
     {
         void OnTriggerEnter(Collider col)
         {
             if (col.gameObject.name == "breakableBox")
             {
                 Destroy(col.gameObject);
             }
         }
     }
