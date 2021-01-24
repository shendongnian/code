    Vector2 gravityUp = Vector2.up;
    Vector2 gravityDown = Vector2.down;
    
    private void ChangeBoyPosition(GameObject target, MouseEventType type)
    {
        if (type == MouseEventType.CLICK)
        {
            int buttonIndex = System.Array.IndexOf(buttons, target);
            if (buttonIndex == 0)
            {
                Physics2D.gravity = gravityDown;
            }
            else
            {
                Physics2D.gravity = gravityUp;
            }
        }
    }
