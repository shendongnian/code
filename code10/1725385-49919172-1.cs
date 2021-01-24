    public class MainActivity : Activity
    {
    	protected override void OnCreate(Bundle savedInstanceState)
    	{
    		base.OnCreate(savedInstanceState);
    
    		var layout = new LinearLayout(this);
    		var editText = new EditText(this)
    		{
    			LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)			
    		};
    
    		if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
    		{
    			editText.BackgroundTintList = ColorStateList.ValueOf(Color.Green);
    		}
    		else
    		{
    			editText.Background.SetColorFilter(Color.Green, PorterDuff.Mode.SrcAtop);
    		}
    
    		layout.AddView(editText);
    
    		SetContentView(layout);
    	}
    }
