    private void Bg_music()
    {
        new System.Threading.Thread(() =>
        {
            bg = new System.Windows.Media.MediaPlayer();
            bg.Open(new System.Uri(path + "Foniqz_-_Spectrum_Subdiffusion_Mix_real.wav"));
            bg.Play();
        }).Start();                        
    }
