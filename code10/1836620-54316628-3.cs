    using UnityEngine;
    public class Platform : MonoBehaviour
    {
    
    SpriteRenderer sprite;
    Vector3 camWorldPos;
    
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        var screen = new Vector2(Screen.width, Screen.height);
        var cam = Camera.main;
        camWorldPos = cam.ScreenToWorldPoint(screen);
        camWorldPos.y -= cam.orthographicSize * 2;
    }
    
    private void Update()
    {
        var height = sprite.bounds.size.y;
        var topOfPlatform = transform.position.y + height / 2;
        if (topOfPlatform < camWorldPos.y)
            Destroy(gameObject);
    }
    }
