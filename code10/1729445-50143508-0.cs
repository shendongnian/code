    private Dictionary<Keyboard.Key, bool> keysArePressed = new Dictionary<Keyboard.Key, bool>
    {
       {Keyboard.Key.A, false},
       {Keyboard.Key.S, false},
       {Keyboard.Key.D, false}
    };
    // Key
    Window.KeyPressed += OnKeyPressed;
    Window.KeyReleased += OnKeyReleased;
    public void OnKeyPressed(object sender, KeyEventArgs e)
    {
       if (e.Code == Keyboard.Key.A && !keysArePressed[Keyboard.Key.A])
       {
          Console.WriteLine("A pressed");
          keysArePressed[Keyboard.Key.A] = true;
       }
    }
    public void OnKeyReleased(object sender, KeyEventArgs e)
    {
       if (e.Code == Keyboard.Key.A)
       {
          Console.WriteLine("A released");
          keysArePressed[Keyboard.Key.A] = false;
       }
    }
