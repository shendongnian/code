    public class TextBoxWatermarked : TextBox
    {
    	private string _watermark;
    	private bool _isWatermarked;
    
    	protected new Brush Foreground
    	{
    		get { return base.Foreground; }
    		set { base.Foreground = value; }
    	}
    
    	public string Watermark
    	{
    		get { return _watermark; }
    		set
    		{
    			_watermark = value;
    			ShowWatermark();
    		}
    	}
    	
    	public TextBoxWatermarked()
    	{
    		Loaded += (s, ea) => ShowWatermark();
    	}
    	
    	protected override void OnGotFocus(RoutedEventArgs e)
    	{
    		base.OnGotFocus(e);
    		HideWatermark();
    	}
    	
    	protected override void OnLostFocus(RoutedEventArgs e)
    	{
    		base.OnLostFocus(e);
    		ShowWatermark();
    	}
    
    	private void ShowWatermark()
    	{
    		if (string.IsNullOrEmpty(base.Text))
    		{
    			_isWatermarked = true;
    			base.Foreground = new SolidColorBrush(Colors.Gray);
    			base.Text = Watermark;
    		}
    	}
    
    	private void HideWatermark()
    	{
    		if (_isWatermarked)
    		{
    			_isWatermarked = false;
    			ClearValue(ForegroundProperty);
    			base.Text = "";
    		}
    	}
    }
