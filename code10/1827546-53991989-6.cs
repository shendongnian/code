To answer your question further, here is a way to implement method #2 in your code. In your player script, you can use OnCollisionEnter and the method above to make the drumstick appear.
    using UnityEngine;
    using System.Collections;
    public class Player : MonoBehaviour
    {  
        void OnCollisionEnter (Collision collision)
        {
            if (collision.gameobject.tag == "drumstick") Drumstick.enabled = false;
        }
    }
For this to work, make sure that the drumstick has the tag "drumstick".
