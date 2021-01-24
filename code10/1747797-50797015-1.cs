    void Update()
        {
            if (platformMovingBack)
                transform.position = Vector2.MoveTowards(transform.position, initialPosition, 20f * Time.deltaTime);
    
            if (Mathf.Abs(transform.position.y - initialPosition.y) < (Time.deltaTime *2.0f)){
                platformMovingBack = false;
                transform.position = initialPosition;
            }
        }
