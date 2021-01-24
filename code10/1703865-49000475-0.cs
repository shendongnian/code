    public MainPage()
    {
        this.InitializeComponent();
        Gamepad.GamepadAdded += Gamepad_GamepadAdded;
    }
    
    private void Gamepad_GamepadAdded(object sender, Gamepad e)
    {
        var controller = Gamepad.Gamepads?.First(); 
        var reading = controller.GetCurrentReading();
    }
