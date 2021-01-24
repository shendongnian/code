    <ComboBox  x:Name="empPositionCB" ItemsSource="{Binding MyPositionFilter}" SelectionChanged="RoleComboBox_SelectionChanged" ....../>
    public ICollectionView MyPositionFilter { get; set; }
    
    //ctor
    public MyUserControlOrWindow()
    {
    	//Before InitComponent()
    	this.MyPositionFilter = new CollectionViewSource { Source = MyPosObservableCollection }.View;
    	
    	
    	InitComponent();
    }
    
    public void RoleComboBox_SelectionChanged(object sender,EventArgs e)
    {
    	//Get the selected Role (the ? is to prevent NullException (VS 2015 >))
    	Role r = empRoleCB.SelectedItem as Role;
    	
    	//Apply the filter
    	this.MyPositionFilter.Filter = item =>
    	{
    		//Make you sure to convert correcteley your Enumeration, I used it here like a class
    		Position p = item as Position;
    		
    		//Put your condition here. For example:
    		return r.ToLowers().Contains(p.ToLower());
    		
    		//Or
    		
    		return (r != null && r.Length >= p.Length);
    	};
    }
