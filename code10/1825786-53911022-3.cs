    [RequireComponent(typeof(MeshCollider))]
    public class UserController : MonoBehaviour
    {
        private Vector3 Dist;
        private float PosX = 0.0f;
        private float PosY = 0.0f;
        private float PosZ = 0.0f;
        private bool shiftOn = false;
        private void OnMouseDown()
        {
            Dist = Camera.main.WorldToScreenPoint(transform.position);
            PosX = Input.mousePosition.x - Dist.x;
            PosY = Input.mousePosition.y - Dist.y;
            PosZ = Input.mousePosition.z - Dist.z;
        }
        private void OnMouseDrag()
        {
            if (Input.GetMouseButton(0))
            {
                if (shiftOn) // 3D drag
                {
                    transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x - PosX, Input.mousePosition.y - PosY, Input.mousePosition.z - PosZ));
                }
                else
                {
                    //Plane Drag
                    Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x - PosX, Input.mousePosition.y - PosY, Input.mousePosition.z - PosZ));
                    transform.position = new Vector3(pos_move.x, transform.position.y, pos_move.z);
                }
            }
        }
       
        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.RightShift))
            {
                Debug.Log("Shift Pressed"); //Logs message to the Unity Console.
                shiftOn = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
            {
                Debug.Log("Shift Released"); //Logs message to the Unity Console.
                shiftOn = false;
            }
        }
