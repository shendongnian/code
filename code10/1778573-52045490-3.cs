    public class GameControl : MonoBehaviour
    {
    private static float speedFactor = 1.0f; // you can set this to canvas scale
    private static float speed = 1.0f;
    public static float ScaledSpeed
    {
        get
        {
            return speed * speedFactor;
        }
    }
    void FixedUpdate()
    {
        speed += 0.01f * Time.deltaTime;
    }
    }
