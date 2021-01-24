    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    
    public class destroy_out_screen : MonoBehaviour
    {
         public GameObject cameraGO; 
         
         
    
         void adapt_collider(){
    
            Vector2 point1 = new Vector2(1,1);
            Vector2 point2 = new Vector2(0,1);
            Vector2 point3 = new Vector2(0,0);
            Vector2 point4 = new Vector2(1,0);
            
            gameObject.GetComponent<PolygonCollider2D>().points = new[]{point1,point2,point3,point4};
        }
        void Start()
        {
            adapt_collider();
        }
    }
