    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Animation;
    using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Messaging;
    using GalaSoft.MvvmLight.Threading;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Windows.Shapes;
    using TwoViews.Models;
    using System.Windows.Media;
    
    namespace TwoViews.Views
    {
        public partial class SecondView : UserControl
        {
            private DoubleAnimation myDoubleAnimation;
    
            public SecondView()
            {
                InitializeComponent();
    
                Messenger.Default.Register<MessageSearchStatus>(this, messageSearchStatus => ReceivedSearchStatus(messageSearchStatus));
    
                /// Animation for loader
                myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = 100;
                myDoubleAnimation.To = 0;
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(.1));
                myDoubleAnimation.AutoReverse = true;
                myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            }
    
            private void ReceivedSearchStatus(MessageSearchStatus message)
            {
                rectangleLoader.BeginAnimation(Rectangle.WidthProperty, myDoubleAnimation);
            }
    
            private void stopAnimation_Click(object sender, System.Windows.RoutedEventArgs e)
            {
                rectangleLoader.BeginAnimation(Rectangle.WidthProperty, null);
            }
        }
    }
