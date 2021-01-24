    pulbic class ObjectMove : MonoBehaviour
    {
        Vector2 targetPos;
        float lerpAmount = 0.05f;
        public bool moving = true;
        void Update()
        {
            transform.position = Vector2.Lerp(transform.position, targetPos, lerpAmount);
            if(transform.position == target.position)
               moving = false;
        }
        public void MoveXY(Vector2 target)
        {
            targetPos = target;
            moving = true;
        }
    }
