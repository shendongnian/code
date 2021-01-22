        static WindowsMediaPlayerClass player;
        static void Main()
        {
            player = new WindowsMediaPlayerClass();  
            IWMPMedia mediaInfo = player.newMedia("test.wmv");
            player.OpenStateChange += new _WMPOCXEvents_OpenStateChangeEventHandler(player_OpenStateChange);
            player.currentMedia = mediaInfo;
            //...
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
        private static void player_OpenStateChange(int state)
        {
            if (state == (int)WMPOpenState.wmposMediaOpen)
            {
                Console.WriteLine( "height = " + player.currentMedia.imageSourceHeight);
                Console.WriteLine( "width = " + player.currentMedia.imageSourceWidth);
            }
        }
