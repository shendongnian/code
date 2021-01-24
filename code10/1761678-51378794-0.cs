    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class PlayerControl : MonoBehaviour {
    
        public GameObject player;
        private List<GameObject> arrows = new List<GameObject>();
    
        void Start()
        {
    
        }
    
        void Update () {
            if (Input.GetMouseButtonDown(0))
            {
                 Shoot();
            }
            foreach(var arrow in arrows) {
                var rb2D = Aprefab.GetComponent<Rigidbody2D>();
                var angle = Mathf.Atan2(rb2D.velocity.y, rb2D.velocity.x);
                arrow.transform.localEulerAngles = new Vector3(0, 0, (angle * 180) / Mathf.PI);
            }
        }
    
        private void Shoot() {
            var a = Input.mousePosition;
            var difference = a - player.transform.position;
            var Aprefab = Instantiate(arrow) as GameObject;
            var rb2D = Aprefab.GetComponent<Rigidbody2D>();
            rb2D.AddForce(difference * 0.02f, ForceMode2D.Impulse);
            arrows.Add(Aprefab);
       }
    }
