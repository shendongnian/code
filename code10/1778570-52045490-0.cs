    public class GameControl : MonoBehaviour
    {
    public static float speed = 1.0f;
    void FixedUpdate()
    {
        speed += 0.01f * Time.deltaTime;
    }
    }
