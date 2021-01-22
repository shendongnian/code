    class Program
    {
 
        static void Main(string[] args)
        {
            rex.Data += new RecorderEx.DataEventHandler(rex_Data);
            rex.Open += new EventHandler(rex_Open);
            rex.Close += new EventHandler(rex_Close);
            rex.Format = pcmFormat;
            rex.StartRecord();
            Console.WriteLine("Please press enter to exit!");
            Console.ReadLine();
            rex.StopRecord();
        }
 
        static RecorderEx rex = new RecorderEx(true);
        static PlayerEx play = new PlayerEx(true);
        static IntPtr pcmFormat = AudioCompressionManager.GetPcmFormat(1, 16, 44100);
 
        static void rex_Open(object sender, EventArgs e)
        {
            play.OpenPlayer(pcmFormat);
            play.StartPlay();
        }
 
        static void rex_Close(object sender, EventArgs e)
        {
            play.ClosePlayer();
        }
 
        static void rex_Data(object sender, DataEventArgs e)
        {
            byte[] data = e.Data;
            play.AddData(data);
        }
    }
