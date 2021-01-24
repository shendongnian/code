    void Main()
    {
    	var test = new myClass();
    	test.Num1 = 1;
    	test.Num2 = 2;
    	test.Num3 = 3;
    	test.Num4 = 4;
    	
    	test.result1.Should().Be(3);
    	test.result2.Should().Be(5);
    	test.result3.Should().Be(6);
    	
    	test.Num1 = 2;
    	test.result1.Should().Be(4);
    	test.Num2 = 0;
    	test.result2.Should().Be(3);
    	test.result3.Should().Be(4);
    }
    
    class myClass : INotifyPropertyChanged
    {
    	// private setter since these values are only being set when the num{i} are updated
    	public int result1 { get; private set; }
    	public int result2 { get; private set; }
    	public int result3 { get; private set; }
    
    	public event PropertyChangedEventHandler PropertyChanged;
    	public myClass()
    	{
    		PropertyChanged += new PropertyChangedEventHandler(UpdateResultValue);
    	}
    
    	private void UpdateResultValue(object sender, PropertyChangedEventArgs e)
    	{
    		result1 = num1 + num2;
    		result2 = num2 + num3;
    		result3 = num2 + num4;
    	}
    
    	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    	{
    	    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    	}
    
    	protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    	{
    		if (EqualityComparer<T>.Default.Equals(field, value)) return false;
    		field = value;
    		OnPropertyChanged(propertyName);
    		return true;
    	}
    
    	private int num1;
    	public int Num1
    	{
    		get => num1;
    		set => SetField(ref num1, value);
    	}
    
    	private int num2;
    	public int Num2
    	{
    		get => num2;
    		set => SetField(ref num2, value);
    	}
    
    	private int num3;
    	public int Num3
    	{
    		get => num3;
    		set => SetField(ref num3, value);
    	}
    
    	private int num4;
    	public int Num4
    	{
    		get => num4;
    		set => SetField(ref num4, value);
    	}
    }
