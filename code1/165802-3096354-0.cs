    public class MyScrollViewer : ScrollViewer
    {
    	protected override void OnKeyDown(KeyEventArgs e)
    	{
    		if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
    		{
    			if (e.Key == Key.Left || e.Key == Key.Right)
    				return;
    		}
    		base.OnKeyDown(e);
    	}
    }
