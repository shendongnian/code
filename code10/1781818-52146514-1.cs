    using System.Linq;
    public class Detector : MonoBehaviour
    {
        public List<SquareItem> Squares
        {
            get; private set;
        }
        public float DetectionRadius = 2f;
        void FixedUpdate()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, DetectionRadius);
            Squares = colliders.ToList().FindAll(el => el.GetComponent<SquareItem>() != null).Select(el => el.GetComponent<SquareItem>()).ToList();
        }
        //This is for drawing the red circle in the inspector so you can control the radius of detection.
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, DetectionRadius);
        }
        public void MoveTowardPos(Vector2 newPos)
        {
            this.transform.position = newPos;
        }
    }
