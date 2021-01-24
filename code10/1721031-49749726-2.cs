    public class FixedMvxUISliderValueTargetBinding : MvxPropertyInfoTargetBinding<UISlider>
    {
    	private IDisposable _subscription;
    	public FixedMvxUISliderValueTargetBinding(object target, PropertyInfo targetPropertyInfo) 
    		: base(target, targetPropertyInfo) { }
    	protected override void SetValueImpl(object target, object value)
    	{
    		var view = target as UISlider;
    		if (view == null) return;
    		view.Value = (float)value;
    	}
    	private void HandleSliderValueChanged(object sender, EventArgs e)
    	{
    		var view = View;
    		if (view == null) return;
    		FireValueChanged(view.Value);
    	}
    
    	public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;
    	public override void SubscribeToEvents()
    	{
    		var slider = View;
    		if (slider == null)
    		{
    			MvxBindingTrace.Trace(
    				MvxTraceLevel.Error, 
    				"Error - UISlider is null in MvxUISliderValueTargetBinding");
    			return;
    		}
    		_subscription = slider.WeakSubscribe(
    			nameof(slider.ValueChanged), 
    			HandleSliderValueChanged);
    	}
    
    	protected override void Dispose(bool isDisposing)
    	{
    		base.Dispose(isDisposing);
    		if (isDisposing)
    		{
    			_subscription?.Dispose();
    			_subscription = null;
    		}
    	}
    }
