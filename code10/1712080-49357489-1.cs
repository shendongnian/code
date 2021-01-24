    using System.IO;
    using WMPLib;
    
    WindowsMediaPlayer player;
    private void button1_Click(object sender, EventArgs e)
    {
     string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Audio Files\name.mp3");
     player = new WindowsMediaPlayer();
     FileInfo fileInfo = new FileInfo(path);
     player.URL = fileInfo.Name;
     player.controls.play();
    }
