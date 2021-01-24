    using UnityEngine;
    using System.Collections;
    public class collision : MonoBehaviour
    {
        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.name == <player_Name>)
            {
                Destroy(this.gameObject);
            }
        }
    }
