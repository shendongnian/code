    namespace MyProject
    {
        public sealed class ViewModel : DependencyObject //handles all databinding voodoo
        {
            public string Susan
	        {
	    	    get { return (string)GetValue(SusanProperty); }
	    	    set { SetValue(SusanProperty, value); }
    	    }
    	    public static readonly DependencyProperty 
                SusanProperty = DependencyProperty.Register
                    ("Susan", typeof(string), 
                    typeof(ViewModel));
        }
    }
