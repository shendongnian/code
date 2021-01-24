    using UnityEngine;
    public class Platform : MonoBehaviour
    {
    
    SpriteRenderer sprite;
    Vector3 camWorldPos;
    
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        var cam = Camera.main;
        var camViewportPos = cam.transform.position;
        camWorldPos = cam.ViewportToWorldPoint(camViewportPos);
    }
    
    private void Update()
    {
        var height = sprite.bounds.size.y;
        var topOfPlatform = transform.position.y + height / 2;
        if (topOfPlatform < camWorldPos.y)
            Destroy(gameObject);
    }
    }
