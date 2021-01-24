    public partial class AnimatingView : ContentView
    {
        string animationName = null;
        public AnimatingView(string AnimationName, bool loop=true, bool autostart=true)
        {
            InitializeComponent();
            animationName = AnimationName;
            animation.Animation = AnimationName;
            if(!loop)
                animation.Loop = loop;
            if(!autostart)
                animation.AutoPlay = autostart;
        }
        protected override void OnParentSet()
        {
            Console.WriteLine(animation.IsPlaying);
            this.Start();
            Console.WriteLine(animation.IsPlaying);
            base.OnParentSet();
        }
        public void Start()
        {
            animation.Play();
        }
        public void Stop()
        {
            animation.AbortAnimation(animationName);
        }
    }
