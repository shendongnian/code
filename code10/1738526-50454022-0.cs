        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        public class PlayerController : MonoBehaviour {
            RaycastHit2D[] hit;
            Vector2[] directions;
            private Vector2 targetPosition;
            private float moveSpeed;
            private float moveHDir;
            private float wallPos;
            private bool hitLeft;
            private bool hitRight;
            // Use this for initialization
            void Start () {
                directions = new Vector2[2] {Vector2.right, Vector2.left};
                hitLeft = false;
                hitRight = false;
            }
            // Update is called once per physics timestamp
            void FixedUpdate () {
                foreach (Vector2 dir in directions) {
                    hit = Physics2D.RaycastAll(transform.position, dir);
                    Debug.DrawRay(transform.position, dir);
                    if (hit[1].collider != null) {
                        // Keyboard control
                        if (Input.GetAxisRaw("Horizontal") != 0) {
                            moveHDir = Input.GetAxisRaw("Horizontal");
                            
                            // I have found that a 5% of the size of the object it's a 
                            // good number to set as a minimal distance from the obj to the borders
                            if (hit[1].distance <= (transform.localScale.x * 0.55f)) {
                                if (dir == Vector2.left) {
                                    hitLeft = true;
                                } else {
                                    hitRight = true;
                                }
                                wallPos = hit[1].collider.transform.position.x;
                                // Condition that guarantee that the paddle do not pass the borders of the screen
                                // but keeps responding if you try to go to the other side
                                if ((wallPos > this.transform.position.x && moveHDir < 0) ||
                                    (wallPos < this.transform.position.x && moveHDir > 0)) {
                                        moveSpeed = gControl.initPlayerSpeed;
                                } else {
                                    moveSpeed = 0;
                                }
                            } else {
                                if (dir == Vector2.left) {
                                    hitLeft = false;
                                } else {
                                    hitRight = false;
                                }
                                if (!hitRight && !hitLeft)
                                {
                                    moveSpeed = gControl.initPlayerSpeed;
                                }
                            }
                        }
                    }
                }
                targetPosition = new Vector2((transform.position.x + (moveSpeed * moveHDir)), transform.position.y);
            }
        }
