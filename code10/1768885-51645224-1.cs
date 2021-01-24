    ObjectAnimationUsingKeyFrames oaukf = new ObjectAnimationUsingKeyFrames
    {
        Duration = time,
        KeyFrames = 
        {
        new DiscreteObjectKeyFrame(Visibility.Visible, new KeyTime())
        }
    };
