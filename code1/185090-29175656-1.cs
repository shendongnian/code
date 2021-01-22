    public enum ProgressBarDisplayText
    {
    	Percentage,
    	CustomText
    }
    
    class ProgressBarWithCaption : ProgressBar
    {
    	//Property to set to decide whether to print a % or Text
    	private ProgressBarDisplayText m_DisplayStyle;
    	public ProgressBarDisplayText DisplayStyle {
    		get { return m_DisplayStyle; }
    		set { m_DisplayStyle = value; }
    	}
    
    	//Property to hold the custom text
    	private string m_CustomText;
    	public string CustomText {
    		get { return m_CustomText; }
    		set {
    			m_CustomText = value;
    			this.Invalidate();
    		}
    	}
        
    	private const int WM_PAINT = 0x000F;
    	protected override void WndProc(ref Message m)
    	{
    		base.WndProc(m);
    
    		switch (m.Msg) {
    			case WM_PAINT:
    				int m_Percent = Convert.ToInt32((Convert.ToDouble(Value) / Convert.ToDouble(Maximum)) * 100);
    				dynamic flags = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine | TextFormatFlags.WordEllipsis;
    
    				using (Graphics g = Graphics.FromHwnd(Handle)) {
    					using (Brush textBrush = new SolidBrush(ForeColor)) {
    
    						switch (DisplayStyle) {
    							case ProgressBarDisplayText.CustomText:
    								TextRenderer.DrawText(g, CustomText, new Font("Arial", Convert.ToSingle(8.25), FontStyle.Regular), new Rectangle(0, 0, this.Width, this.Height), Color.Black, flags);
    								break;
    							case ProgressBarDisplayText.Percentage:
    								TextRenderer.DrawText(g, string.Format("{0}%", m_Percent), new Font("Arial", Convert.ToSingle(8.25), FontStyle.Regular), new Rectangle(0, 0, this.Width, this.Height), Color.Black, flags);
    								break;
    						}
    
    					}
    				}
    
    				break;
    		}
    
    	}
    
    }
