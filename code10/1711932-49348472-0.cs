    using UnityEngine;
    
    public class rotateScreen : MonoBehaviour {
        public float rotationSpeed = 360.0f;
        CursorLockMode wantedMode;
        // Use this for initialization
        void Start () {
            wantedMode = Cursor.lockState = CursorLockMode.Locked;
            // Hide cursor when locked
            Cursor.visible = false;
        }
    	
    	// Update is called once per frame
    	void Update () {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(wantedMode == CursorLockMode.Locked)
                {
                    wantedMode = Cursor.lockState = CursorLockMode.None;
                    // Hide cursor when locked
                    Cursor.visible = true;
    
                }
                else
                {
                    wantedMode = Cursor.lockState = CursorLockMode.Locked;
                    // Show our cursor when unlocked
                    Cursor.visible = false;
    
                }
            }
    
            if (wantedMode == CursorLockMode.Locked)
            {
                Vector3 rotation = Vector3.zero;
                rotation.y = Input.GetAxis("Mouse X");
    
                transform.Rotate(rotation * Time.deltaTime);
            }
        }
    }
