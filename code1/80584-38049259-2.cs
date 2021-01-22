    using System.Windows.Media
    Function void Play(string audioPath)
    {
    MediaPlayer myPlayer = new MediaPlayer();
    myPlayer.Open(new System.Uri(audioPath));
    myPlayer.Play();
    }
    Play(Application.StartupPath + "\\Track1.wav");
    Play(Application.StartupPath + "\\Track2.wav");
