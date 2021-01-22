    public class Person
    {
     	public string Name { get; set; }
     	public int Age { get; set; }
     	private DateTime _dob;
     	public DateTime DateOfBirth
     	{
	     	get
     		{
     			if (_dob is null)
     			{ _dob = DateTime.Today.AddYears(Age * -1); }
     			else { return _dob; }     
     		}
     		set { _dob = value; }
     	}
     }
