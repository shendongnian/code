    using UnityEngine;
    using System.Collections;
    
    public class moveTowards : MonoBehaviour
    {
    
        public Transform target;
    
    
        public float speed;
    
        void OnEnable()
        {
          //Way 1 -> Less optimal
          target = GameObject.Find("PlayerObjectName").transform;
    
          //Way 2 -> Not the best, you need to add a Tag to your player, let's guess that the Tag is called "Player"
          target = GameObject.FindGameObjectWithTag("Player").transform;
    
          //Way 3 -> My favourite, you need to update your Player prefab (I attached the changes below)
          target = Player.s_Singleton.gameObject.transform;
        }
    
        void Update()
        {
    
            float step = speed * Time.deltaTime;
    
    
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }
