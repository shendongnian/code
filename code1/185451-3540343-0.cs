    using System;
    using System.Windows.Media.Animation;
    using System.Windows;
    using System.Collections.Generic; 
    using System.Linq; 
    using System.Text;
    using System.Windows.Shapes;
    
    namespace WpfApplication10 { /// /// Interaction logic for Window1.xaml ///
    
    public partial class Window1: Window
    {
        public Window1()
        {
            InitializeComponent();
    
            DoubleAnimation animate = new DoubleAnimation();
            animate.To = 300;
            animate.Duration = new Duration(TimeSpan.FromSeconds(5));
            animate.RepeatBehavior = RepeatBehavior.Forever;
            clock = animate.CreateClock();
        }
    
        AnimationClock clock;
        void StartAnimation()
        {        
            test.ApplyAnimationClock(Ellipse.WidthProperty, clock);
        }
    
        void PauseAnimation()
        {
            clock.Controller.Pause();
        }
    
        void ResumeAnimation()
        {
            clock.Controller.Resume();
        }
    
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            StartAnimation(); 
        }
    
       }
    }
