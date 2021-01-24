    enum Direction
    {
        Left,
        Right
    }
    
    Direction moveDir;
    float progress;
    
    public void MovePlayer (Direction dir)
    {
        moveDir = dir;
        progress = 0.0f;
    }
    
    public void Update()
    {
        switch(dir)
        {
            case Direction.Left:
            if (currentPosition == Position.Middle)
            {
                transform.position = Vector3.Lerp(middlePos.position, leftPos.position, progress);
                if(progress >= 1.0f)
                    currentPosition = Position.Left;
                else
                    progress += 0.1f; // change as necessary
            }
    
            if (currentPosition == Position.Right)
            {
                transform.position = Vector3.Lerp(rightPos.position, middlePos.position, progress);
                if(progress >= 1.0f)
                    currentPosition = Position.Middle;
                else
                    progress += 0.1f; // change as necessary
            }
            break;
            case Direction.Right:
            // ...
            break;
        }
    }
