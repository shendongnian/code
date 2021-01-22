    public class Speaker
    {
        public Speaker()
        {
            this.MyTweeter = new Tweeter();
        }
        public Tweeter MyTweeter { get; private set; }
        public event SpeakToMeHandler SpeakToMe
        {
            add { MyTweeter.SpeakToMe += value; }
            remove { MyTweeter.SpeakToMe -= value; }
        }
    }
