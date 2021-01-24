    public partial class ViewController : NSViewController
        {
            // ...
            private NSButton startStopButton;
            Timer _timer = new Timer();
           
            private void SetupView()
            { 
            // ...
        subtitlesPanel.KeyPressed += SubtitlesPanel_KeyPressed;
              
            // ...   
                IntializeKeepWindowFocusedTimer();
            }
    
            void SubtitlesPanel_KeyPressed(KeyCodeEventArgs e)
            {
                switch(e.Key)
                {
                    case KeyCode.Left:
                        backButton.PerformClick(this);
                        break;
                    case KeyCode.Right:
                        forwardButton.PerformClick(this);
                        break;
                    case KeyCode.Space:
                        startStopButton.PerformClick(this);
                            break;
                    case KeyCode.Esc:
                        _timer.Stop();
                        break;
                }
            }
    
    
            private void IntializeKeepWindowFocusedTimer()
            {
                _timer.Interval = 200;  //in milliseconds
                _timer.Elapsed += Timer_Elapsed;;
                _timer.AutoReset = true;
                _timer.Enabled = true;
            }
    
            void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                NSApplication.SharedApplication.BeginInvokeOnMainThread(() =>
                {
                    subtitlesPanel.MakeKeyWindow();
                    if (SetSubtitleNeeded)
                    {
                        subtitlesProvider.SetSubTitle(0);
                        startStopButton.Title = "Stop";
                        SetSubtitleNeeded = false;
                        _timer.Interval = 5000;
                    }
                });
            }
    
            private bool SetSubtitleNeeded = false;
    
            partial void ClickedButton(NSObject sender)
            {
                _timer.Stop();
                var nsUrl = subtitleFileSelector.GetFile();
                if (nsUrl == null)
                    return;
    
                fileName = nsUrl.Path;
                subtitlesProvider.ReadFromFile(fileName);
                SetSubtitleNeeded = true;
                _timer.Start();
            }
