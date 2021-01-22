    input.MoveMouseTo(5, 5);
    input.MoveMouseBy(25, 25);
    input.SendLeftClick();
    
    input.KeyDelay = 1; // See below for explanation; not necessary in non-game apps
    input.SendKeys(Keys.Enter);  // Presses the ENTER key down and then up (this constitutes a key press)
    
    // Or you can do the same thing above using these two lines of code
    input.SendKeys(Keys.Enter, KeyState.Down);
    Thread.Sleep(1); // For use in games, be sure to sleep the thread so the game can capture all events. A lagging game cannot process input quickly, and you so you may have to adjust this to as much as 40 millisecond delay. Outside of a game, a delay of even 0 milliseconds can work (instant key presses).
    input.SendKeys(Keys.Enter, KeyState.Up);
    
    input.SendText("hello, I am typing!");
    
    /* All these following characters / numbers / symbols work */
    input.SendText("abcdefghijklmnopqrstuvwxyz");
    input.SendText("1234567890");
    input.SendText("!@#$%^&*()");
    input.SendText("[]\\;',./");
    input.SendText("{}|:\"<>?");
