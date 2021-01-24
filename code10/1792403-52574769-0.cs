    public MainPage()
    {
        this.InitializeComponent();
        ElementSoundPlayer.State = ElementSoundPlayerState.On;
        CurrentVol.Value = ElementSoundPlayer.Volume * 10;
    }
    
    private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        Slider slider = sender as Slider;
        double volumeLevel = slider.Value / 10;
        ElementSoundPlayer.Volume = volumeLevel;
    }
