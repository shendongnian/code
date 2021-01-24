    using UnityEngine;
    public class Platform : MonoBehaviour
    {
    
    SpriteRenderer sprite;
    float bottomOfScreen;
    
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        var cam = Camera.main;
        var screen = new Vector2(Screen.width, Screen.height);
        var camWorldPos = cam.ScreenToWorldPoint(screen);
        bottomOfScreen = camWorldPos.y - cam.orthographicSize * 2;
    }
    
    private void Update()
    {
        var height = sprite.bounds.size.y;
        var topOfPlatform = transform.position.y + height / 2;
        if (topOfPlatform < bottomOfScreen)
            Destroy(gameObject);
    }
    }
