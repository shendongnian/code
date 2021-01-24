    public class Pin : MonoBehaviour
    {
        ...
        void FixedUpdate() 
        {
            if (moving)
                rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
        }
        void OnTriggerEnter2D(Collider2D collider) 
        {
            ...
        }
    }
