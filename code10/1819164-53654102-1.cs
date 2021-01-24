    public List<var> elList = new List<var>();
    public List<DoubleAnimationUsingKeyFrames> daList = new List<DoubleAnimationUsingKeyFrames>();
    public int i = 0;
    Storyboard sb = new Storyboard();
    KeyTime keyTime1 = KeyTime.FromTimeSpan(new TimeSpan(0));
    KeyTime keyTime2 = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 1, 500));
    foreach(var el in elements)
    {
        elList.Add(el);
        DoubleAnimationUsingKeyFrames da = new DoubleAnimationUsingKeyFrames();
        da.KeyFrames.Add(keyTime1.GetKeyFrame(0));
        da.KeyFrames.Add(keyTime2.GetKeyFrame(1));
        Storyboard.SetTargetProperty(da, "Opacity");
        daList.Add(da);
        Storyboard.SetTarget(da[i], el[i]);
        sb.Children.Add(da[i]);
        i++
    }
    sb.Begin();
