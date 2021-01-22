    class Program
    {
        
        static void Main(string[] args)
        {
            Console.Clear();
    
            try
            {
                Speaker speaker = new Speaker();
                speaker.speakerEvent += new SpeakToMeHandler(Program.OnSpeak);
    
                // Cause events to be fied
                speaker.Tweeter.CauseEvent();
                speaker.Woofer.CauseEvent();
    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                Console.WriteLine("Stacktrace: {0}", ex.StackTrace);
            }
        }
    
        public static void OnSpeak(object sendere, SpeakToMeEventArgs e)
        {
            Console.WriteLine("OnSpeak Message = {0}", e.Message);
        }
        
    }
    
    public delegate void SpeakToMeHandler(object sender, SpeakToMeEventArgs e);
    
    public class SpeakToMeEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
    
    public class Speaker
    {
        public event SpeakToMeHandler speakerEvent;
    
        public Tweeter Tweeter { get; set; }
        public Woofer Woofer { get; set; }
    
        public void OnSpeakToMeHander(object sender, SpeakToMeEventArgs e)
        {
            if (this.speakerEvent != null)
            {
                SpeakToMeEventArgs args = new SpeakToMeEventArgs
                    {
                        Message = string.Format("OnSpeakToMeHander Orginal Message: {0}", e.Message)
                    };
    
                this.speakerEvent(this, args);
            }
        }
    
        public Speaker()
        {
            this.Tweeter = new Tweeter();
            this.Woofer = new Woofer();
    
            Tweeter.tweeterEvent += new SpeakToMeHandler(this.OnSpeakToMeHander);
            Woofer.wooferEvent += new SpeakToMeHandler(this.OnSpeakToMeHander);
        }
    }
    
    public class Tweeter
    {
        public event SpeakToMeHandler tweeterEvent;
    
        public void CauseEvent()
        {
            SpeakToMeEventArgs args = new SpeakToMeEventArgs()
                {
                    Message = "Fired By Tweeter"
                };
    
            if (this.tweeterEvent != null)
            {
                this.tweeterEvent(this, args);
            }
        }
    }
    
    public class Woofer
    {
        public event SpeakToMeHandler wooferEvent;
    
        public void CauseEvent()
        {
            SpeakToMeEventArgs args = new SpeakToMeEventArgs()
                {
                    Message = "Fired By Woofer"
                };
    
            if (this.wooferEvent != null)
            {
                this.wooferEvent(this, args);
            }
        }
    }
