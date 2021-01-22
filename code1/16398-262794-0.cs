    public class CustomControl : Control
    {
    	public static readonly DependencyProperty PersonProperty =
    		DependencyProperty.Register("Person", typeof(Person), typeof(CustomControl), new UIPropertyMetadata(null));
    	public Person Person
    	{
    		get { return (Person) GetValue(PersonProperty); }
    		set { SetValue(PersonProperty, value); }
    	}
    
    
    	public static readonly DependencyProperty JobProperty =
    		DependencyProperty.Register("Job", typeof(Job), typeof(CustomControl), new UIPropertyMetadata(null));
    	public Job Job
    	{
    		get { return (Job) GetValue(JobProperty); }
    		set { SetValue(JobProperty, value); }
    	}
    
    	static CustomControl()
    	{
    		DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl), new FrameworkPropertyMetadata(typeof(CustomControl)));
    	}
    }
