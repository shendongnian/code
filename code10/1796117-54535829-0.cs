    public class PlayerBall : MonoBehaviour {
      public float thrust = 10;
      Rigidbody2D body;
      Vector2 forwardDirection = Vector2.right;
      void Awake() {
        body = GetComponent<Ridigbody2d>();
      }
      // FixedUpdate is called once per physics update
      void FixedUpdate () {
        body.AddForce(forwardDirection * thrust)
      }
    }
