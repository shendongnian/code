    [TemplateVisualState(Name = "TextBlock", GroupName = "ControlType")]
	[TemplateVisualState(Name = "TextBox", GroupName = "ControlType")]
	public class TextBox2 : TextBox
	{
		public TextBox2()
		{
			DefaultStyleKey = typeof (TextBox2);
			Loaded += (s, e) => UpdateVisualState(false);
		}
		private bool isTextBlock;
		public bool IsTextBlock
		{
			get { return isTextBlock; }
			set
			{
				isTextBlock = value;
				UpdateVisualState(true);
			}
		}
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			UpdateVisualState(false);
		}
		
		internal void UpdateVisualState(bool useTransitions)
		{
			if (IsTextBlock)
			{
				VisualStateManager.GoToState(this, "TextBlock" , useTransitions);
			}
			else
			{
				VisualStateManager.GoToState(this, "TextBox" , useTransitions);
			}
		}
	}
