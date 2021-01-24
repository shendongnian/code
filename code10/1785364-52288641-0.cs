    public class PlayerMove : MonoBehaviour 
    {
        ...
       
        private float rotationX;
        ...
        void Rotate(float _camRot)
        {
            rotationX += _camRot * sensitivityY;
            rotationX = Mathf.Clamp(rotationX, -75, 50);
            camTrans.localEulerAngles = new Vector3(rotationX, camTrans.localEulerAngles.y, camTrans.localEulerAngles.z);
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation * sensitivityX));
        }
