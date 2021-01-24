    if (Keyboard.GetState().IsKeyDown(Keys.Right))
    {
        if(!flag)
        {
            mx += 100;
            flag = true; // set when changing value
        }
    }
    else
        flag = false; // reset when button is not down
