    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Slash : MonoBehaviour 
    {
        LineRenderer myRenderer;
        public float mouseZ = -2f;
        Vector3[] positions = new Vector3[2] {Vector3.zero, Vector3.zero};
    
        void Start() 
        {
            myRenderer = this.getComponent<LineRenderer>();
        }
    
        void Update() 
        { 
            UpdateMouse();
        }
      
        void UpdateMouse() 
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                UpdatePositions(0);
            }
            else if(Input.GetMouseButton(0)) 
            {
                UpdatePositions(1);
            } 
            else if(Input.GetMouseButtonUp(0)) 
            {
                 UpdatePositions(1);
                 HandleCollisions();
            }
        }
    
        Vector3 GetNewPosition() 
        {
            // Method assumes you are using an orthographic camera.
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePositions);
            // Set the Z position so we can see it from the camera (it would use the same z as the camera otherwise)
            mousePosition.z = mouseZ;
            return mousePosition;
        }
    
        void updatePositions(int index) 
        {
             if(index >= positions.Length) 
             {
                 Debug.LogError("Invalid index was given: " + index);
                 return;
             }
    
             positions[index] = GetNewPosition();
             myRenderer.positionCount = index + 1;
             myRenderer.SetPositions(positions);
        }
    
        void HandleCollisions() 
        {
            RaycastHit2D[] rays = Physics2D.LinecastAll(positions[0], positions[1]);
 
            if(rays != null && rays.length > 1) 
            {
                // Checking only the first and second indices of the array, if you want to allow
                // The users to collide with multiple objects this is where you would change that logic.
                // Using name for now, but may be better if you compared them via tag, layer, or gave them a script that defined their type.
                 if(rays[0].collider.gameObject.name.Equals(rays[1].collider.gameObject.name)) 
                 {
                      rays[0].collider.gameObject.SetActive(false);
                      rays[1].collider.gameObject.SetActive(false);
                 }
            }
            positions = new Vector3[2] {Vector3.zero, Vector3.zero};
        }
    
    }
