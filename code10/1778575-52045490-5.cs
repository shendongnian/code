    public class ObstacleScrolling : MonoBehaviour
    {
    void FixedUpdate()
    {
        this.transform.Translate(Vector3.right * GameControl.ScaledSpeed);
    }
    }
