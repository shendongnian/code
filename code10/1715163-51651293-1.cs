    public class swipeTest : MonoBehaviour {
        private void Update() {
        desiredPosition = Player.position;
            if (swipeControls.SwipeLeft)
                desiredPosition += Vector3.left;
            if (swipeControls.SwipeRight)
                desiredPosition += Vector3.right;
            Player.transform.position = Vector3.MoveTowards
                (Player.transform.position, desiredPosition, 0.5f * Time.deltaTime);
        }
    }
