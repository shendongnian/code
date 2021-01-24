     private void Button_Click(object sender, RoutedEventArgs e)
            {
                savetxt.Visibility = Visibility.Visible;
    
                Storyboard storyboard = new Storyboard();
                TimeSpan duration = new TimeSpan(0, 0, 5);
                DoubleAnimation animation = new DoubleAnimation();
    
                animation.From = 1.0;
                animation.To = 0.0;
                animation.Duration = new Duration(duration);
            
                Storyboard.SetTargetName(animation, savetxt.Name);
                Storyboard.SetTargetProperty(animation, new PropertyPath(OpacityProperty));
                // Add the animation to the storyboard
                storyboard.Children.Add(animation);
    
                // Begin the storyboard
                storyboard.Begin(this);
    
                MessageBox.Show(savetxt.Visibility.ToString());
            }        
