    public partial class SecurePage : UserControl
    {
    	public VisualStateGroup vsGroup = new VisualStateGroup();
    
    	public SecurePage()
    	{
    		System.Collections.IList groups = VisualStateManager.GetVisualStateGroups(this);
    
    
    		VisualState state1 = new VisualState() { Name = "State1" };
    
    		Storyboard sb = new Storyboard();
    		DoubleAnimation anim = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(1.0));
    		Storyboard.SetTargetProperty(anim, new PropertyPath(FrameworkElement.OpacityProperty));
    		sb.AutoReverse = true;
    		sb.Children.Add(anim);
    
    		state1.Storyboard = sb;
    
    		vsGroup.States.Add(state1);
    
    		groups.Add(vsGroup);
    	}
    }
