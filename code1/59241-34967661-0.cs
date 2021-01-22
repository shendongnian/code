    using System.Windows.Controls.Primitives;
    
    public class AutoCheckBox : CheckBox
    {
    
    	private bool _autoCheck = false;
    	public bool AutoCheck {
    		get { return _autoCheck; }
    		set { _autoCheck = value; }
    	}
    
    	protected override void OnClick()
    	{
    		if (_autoCheck) {
    			base.OnClick();
    		} else {
    			base.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent, this));
    		}
    	}
    
    }
