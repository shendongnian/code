    <TextBlock Text="...">
        <TextBlock.Style>
            <Style TargetType="TextBlock">
                <EventSetter Event="MouseDown" Handler="Mouse_LBtnDown"/>
            </Style>
        </TextBlock.Style>
    </TextBlock>
    
    private void Mouse_LBtnDown(object sender, MouseButtonEventArgs e)
    {
    	StackPanel stp = null;
    	var visParent = VisualTreeHelper.GetParent(sender as FrameworkElement);
    	while (stp == null && visParent != null)
    	{
    		stp = visParent as StackPanel;
    		visParent = VisualTreeHelper.GetParent(visParent);
    	}
    	if (stp == null) { return; }
    
    	stp.Background = Brushes.Coral;
    }
