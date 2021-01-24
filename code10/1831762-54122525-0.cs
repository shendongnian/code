    class FixedJoystick : Joystick
    {
        public Vector2 InputVector
        {
            get { return this.inputVector; }
        }
    }
    class CalleAll : MonoBehaviour
    {
        void Update()
        {
            var fps = GetComponent<RigidbodyFirstPersonController>();
            fps.RunAxis = this.MoveJoystick.InputVector;
        }
    }
