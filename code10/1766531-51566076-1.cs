    public class TimerWallpaper
    {
        public string TimerFileName { get; set; }
        public BitmapImage TimerImgSource { get; set; }
        public string TimerTime { get; set; }
        public TimerWallpaper(string name, BitmapImage imgSource, int hours, int mins)
        {
            this.TimerFileName = name;
            this.TimerImgSource = imgSource;
            this.TimerTime = hours.ToString() + " : " + mins.ToString();
        }
    }
