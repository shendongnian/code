	public class BindingProxyForTemplateSelector : Freezable
	{
		#region Overrides of Freezable
		protected override Freezable CreateInstanceCore()
		{
			return new BindingProxyForTemplateSelector();
		}
		#endregion
		public object DataIn
		{
			get { return (object)GetValue(DataInProperty); }
			set { SetValue(DataInProperty, value); }
		}
	    public object DataOut
	    {
	        get { return (object) GetValue(DataOutProperty); }
	        set { SetValue(DataOutProperty, value); }
	    }
        public object Trigger
	    {
	        get { return (object) GetValue(TriggerProperty); }
	        set { SetValue(TriggerProperty, value); }
	    }
	    public static readonly DependencyProperty TriggerProperty = DependencyProperty.Register(nameof(Trigger), typeof(object), typeof(BindingProxyForTemplateSelector), new PropertyMetadata(default(object), OnTriggerValueChanged));
		public static readonly DependencyProperty DataInProperty = DependencyProperty.Register(nameof(DataIn), typeof(object), typeof(BindingProxyForTemplateSelector), new UIPropertyMetadata(null, OnDataChanged));
	    public static readonly DependencyProperty DataOutProperty = DependencyProperty.Register(nameof(DataOut), typeof(object), typeof(BindingProxyForTemplateSelector), new PropertyMetadata(default(object)));
	    private static void OnTriggerValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	    {
            // this does the whole trick
            var sender = d as BindingProxyForTemplateSelector;
            if (sender == null)
                return;
	        sender.DataOut = null; // set to null and then back triggers the TemplateSelector to search for a new template
	        sender.DataOut = sender.DataIn;
	    }
	    private static void OnDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	    {
            var sender = d as BindingProxyForTemplateSelector;
	        if (sender == null)
	            return;
	        sender.DataOut = e.NewValue;
	    }
	}
