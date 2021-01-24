    using UnityEngine;
    public class Ball : MonoBehaviour
    {
    
    private LineRenderer line; 
    private Rigidbody2D rb;
    private bool hit;
    
    void Start()
    {
        line = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        line.SetPosition(0, transform.position);
        if (Input.GetMouseButton(0))
        {
            line.startWidth = .05f;
            line.endWidth = .05f;
            line.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));           
        }
        else
        {
            line.startWidth = 0;
            line.endWidth = 0;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            hit = true;           
        }
    }
    
    private void FixedUpdate()
    {
        if (hit)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rb.AddForce(direction * 3f, ForceMode2D.Impulse);
            hit = false;
        }
    }
    }
