    MediaPlayer bg;
    
    public game_form()
    {
        InitializeComponent();
        Bg_music(); //Calling the background music thread at the time user start playing the game.
        path = Directory.GetCurrentDirectory();
        path = path + "\\..\\..\\Resources\\";
        Aanet_checking();
        Translate();
        Character_checking();
    }
