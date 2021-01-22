    Image creatureImage = new Image();    
    Storyboard fadeInFadeOut = new Storyboard();
        
        DoubleAnimationUsingKeyFrames dbAnimation = new DoubleAnimationUsingKeyFrames();
                    dbAnimation.Duration = TimeSpan.FromSeconds(2);
                    LinearDoubleKeyFrame lDKF1 = new LinearDoubleKeyFrame();
                    lDKF1.Value = 1;
                    lDKF1.KeyTime = TimeSpan.FromSeconds(0);
                    dbAnimation.KeyFrames.Add(lDKF1);
                    //
                    LinearDoubleKeyFrame lDKF2 = new LinearDoubleKeyFrame();
                    lDKF2.Value = 0.6;
                    lDKF2.KeyTime = TimeSpan.FromSeconds(0.5);
                    dbAnimation.KeyFrames.Add(lDKF2);
                    //
                    LinearDoubleKeyFrame lDKF3 = new LinearDoubleKeyFrame();
                    lDKF3.Value = 1;
                    lDKF3.KeyTime = TimeSpan.FromSeconds(0.5);
                    dbAnimation.KeyFrames.Add(lDKF3);
                    //
                    LinearDoubleKeyFrame lDKF4 = new LinearDoubleKeyFrame();
                    lDKF4.Value = 0;
                    lDKF4.KeyTime = TimeSpan.FromSeconds(1);
                    dbAnimation.KeyFrames.Add(lDKF4);
        
                    Storyboard.SetTarget(dbAnimation, creatureImage);
                    Storyboard.SetTargetProperty(dbAnimation, new PropertyPath(Image.OpacityProperty));
                    fadeInFadeOut.Children.Add(dbAnimation);
