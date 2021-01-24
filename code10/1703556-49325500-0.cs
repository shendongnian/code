    var thumbSticks = new GamePadThumbSticks(new Vector2(1, 1), new Vector2(0, 0));
    var triggers = new GamePadTriggers(0, 1);
    var buttons = new GamePadButtons(Buttons.A);
    var dPad = new GamePadDPad(ButtonState.Released, ButtonState.Pressed, ButtonState.Released, ButtonState.Released);
    var cState = new GamePadState(thumbSticks, triggers, buttons, dPad);
    var cState2 = GamePadState.Default;
    Console.WriteLine(cState == cState2); //false
