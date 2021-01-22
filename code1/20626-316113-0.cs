    public partial class Window1 : Window
    {
        Storyboard a = new Storyboard();
        StringAnimationUsingKeyFrames timeline = new StringAnimationUsingKeyFrames();
        DiscreteStringKeyFrame keyframe = new DiscreteStringKeyFrame();
        
        int i;
        public Window1()
        {
            InitializeComponent();
            //RunTimeline();
            RunStoryboard();
        }
        private void RunTimeline()
        {
            timeline.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("(TextBlock.Text)"));
            timeline.Completed += timeline_Completed;
            timeline.Duration = new Duration(TimeSpan.FromMilliseconds(10));
            textblock.BeginAnimation(TextBlock.TextProperty, timeline);
        }
        private void RunStoryboard()
        {
            timeline.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("(TextBlock.Text)"));
            a.Children.Add(timeline);
            a.Completed += a_Completed;
            a.Duration = new Duration(TimeSpan.FromMilliseconds(10));
            a.Begin(textblock);
        }
        void timeline_Completed(object sender, EventArgs e)
        {
            textblock.Text = (++i).ToString();
            textblock.BeginAnimation(TextBlock.TextProperty, timeline);
        }
        void a_Completed(object sender, EventArgs e)
        {
            textblock.Text = (++i).ToString();
            a.Begin(textblock);
        }
    }
