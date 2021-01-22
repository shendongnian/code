    public BindingList<User> Users
    	{
    	    get { return (BindingList<User>)GetValue(UsersProperty); }
    	    set { SetValue(UsersProperty, value); }
    	}
    
    public static readonly DependencyProperty UsersProperty =
    	DependencyProperty.Register("Users", typeof(BindingList<User>), 
          typeof(OptionsDialog));
