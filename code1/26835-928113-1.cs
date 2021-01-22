    using System;
    using System.Threading;
    using System.Windows.Media;
    using System.Windows.Threading;
    class Program
    {
        static void Main(string[] args)
        {
            var mediaFile = @"c:\path\to\mediafile.mp3";
            var duration = GetMediaDuration(mediaFile, TimeSpan.FromMilliseconds(500));
            Console.WriteLine(duration.ToString());
            Console.ReadKey();
        }
        static TimeSpan GetMediaDuration(string mediaFile)
        {
            return GetMediaDuration(mediaFile, TimeSpan.Zero);
        }
        static TimeSpan GetMediaDuration(string mediaFile, TimeSpan maxTimeToWait)
        {
            var mediaData = new MediaData() {MediaUri = new Uri(mediaFile)};
            var thread = new Thread(GetMediaDurationThreadStart);
            DateTime deadline = DateTime.Now.Add(maxTimeToWait);
            thread.Start(mediaData);
            
            while (!mediaData.Done && ((TimeSpan.Zero == maxTimeToWait) || (DateTime.Now < deadline)))
                Thread.Sleep(100);
            
            Dispatcher.FromThread(thread).InvokeShutdown();
            if (!mediaData.Done)
                throw new Exception(string.Format("GetMediaDuration timed out after {0}", maxTimeToWait));
            if (mediaData.Failure)
                throw new Exception(string.Format("MediaFailed {0}", mediaFile));
            return mediaData.Duration;
        }
        static void GetMediaDurationThreadStart(object context)
        {
            var mediaData = (MediaData) context;
            var mediaPlayer = new MediaPlayer();
            mediaPlayer.MediaOpened += 
                delegate 
                    {
                        if (mediaPlayer.NaturalDuration.HasTimeSpan)
                            mediaData.Duration = mediaPlayer.NaturalDuration.TimeSpan; 
                        mediaData.Success = true; 
                        mediaPlayer.Close();
                    };
            mediaPlayer.MediaFailed += 
                delegate
                    {
                        mediaData.Failure = true;
                        mediaPlayer.Close();
                    };
            
            mediaPlayer.Open(mediaData.MediaUri);
            
            Dispatcher.Run();
        }
    }
    class MediaData
    {
        public Uri MediaUri;
        public TimeSpan Duration = TimeSpan.Zero;
        public bool Success;
        public bool Failure;
        public bool Done { get { return (Success || Failure); } }
    }
