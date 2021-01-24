    using UnityEngine;
    
    public class rotatorScript: MonoBehaviour {
        void Update() {
            // Will Rotate based off of left/right arrows
            float rotator = -Input.GetAxisRaw("Horizontal");
            // Move up or down based off of up/down Arrows
            float verticalDirection = Input.GetAxisRaw("Vertical");
            // Do the actual movement... using space.self so it is based on the player not the world.
            transform.Translate(Vector3.up * verticalDirection * Time.deltaTime * 5f, Space.self);
            transform.Rotate(0f,0f,90f * Time.deltaTime * rotator); 
        }
    }
