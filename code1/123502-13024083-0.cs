            var storyBoard = new Storyboard();
            var group = new TransformGroup();
            var scale = new ScaleTransform(Zoom, Zoom);
            group.Children.Add(scale);
            group.Children.Add(new TranslateTransform(_translateX,_translateY));
            MainCanvas.RenderTransform = group;
            RegisterName("MainCanvas",MainCanvas);
            var growAnimation = new DoubleAnimation();
            growAnimation.Duration = TimeSpan.FromMilliseconds(1000);
            growAnimation.From = _oldZoom;
            growAnimation.To = Zoom;
            storyBoard.Children.Add(growAnimation);
            var growAnimation2 = new DoubleAnimation();
            growAnimation2.Duration = TimeSpan.FromMilliseconds(1000);
            growAnimation2.From = _oldZoom;
            growAnimation2.To = Zoom;
            
            storyBoard.Children.Add(growAnimation2);
            
            string thePath = "(0).(1)[0].(2)"; // Not used - just to show the syntax
            
            Storyboard.SetTargetProperty(growAnimation, new PropertyPath("RenderTransform.Children[0].ScaleX"));
            Storyboard.SetTargetProperty(growAnimation2, new PropertyPath("RenderTransform.Children[0].ScaleY"));
            Storyboard.SetTargetName(growAnimation, "MainCanvas");
            Storyboard.SetTargetName(growAnimation2,"MainCanvas");
            storyBoard.Begin(this);
