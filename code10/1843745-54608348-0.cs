    public class rotate : MonoBehaviour
    {
    public float speed;
    Vector2 pos;
    private void Start()
    {
        speed = 100;
    }
    private void Update()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 posInScreen = touch.position;
            
            if (Camera.current.ScreenToWorldPoint(posInScreen) != null)
            {
                 pos = Camera.current.ScreenToWorldPoint(posInScreen);
            }
            float Xposition = pos.x;
            transform.rotation = Quaternion.Euler(0, 0, Xposition*speed);
        }
    }
    }
