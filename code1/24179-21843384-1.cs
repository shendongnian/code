    string result = "";
    public override void Update(GameTime gameTime)
    {
        KeyboardState state = Keyboard.GetState();
        int i = 0;
        foreach (Keys key in keys)
        {
            if (state.IsKeyDown(key))
            {
                if (IskeyUp[i])
                {
                    if (key == Keys.Back && result != "") result = result.Remove(result.Length - 1);
                    if (key == Keys.Space) result += " ";
                    if (i > 1 && i < 12)
                    {
                        if (state.IsKeyDown(Keys.RightShift) || state.IsKeyDown(Keys.LeftShift))
                            result += SC[i - 2];//if shift is down, and a number is pressed, using the special key
                        else result += key.ToString()[1];
                    }
                    if (i > 11 && i < 38)
                    {
                        if (state.IsKeyDown(Keys.RightShift) || state.IsKeyDown(Keys.LeftShift))
                           result += key.ToString();
                        else result += key.ToString().ToLower(); //return the lowercase char is shift is up.
                    }
                }
                IskeyUp[i] = false; //make sure we know the key is pressed
            }
            else if (state.IsKeyUp(key)) IskeyUp[i] = true;
            i++;
        }
        base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
    }
