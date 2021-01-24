        private void Bg_music()
        {
            bg = new System.Windows.Media.MediaPlayer();
            new System.Threading.Thread(() =>
            {
                bg.Dispatcher.Invoke(()=>{
                    bg.Open(new System.Uri(path + "Foniqz_-_Spectrum_Subdiffusion_Mix_real.wav"));
                    bg.Play();
                });
                
            }).Start();                        
        }
