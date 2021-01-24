    public class Customer
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public string Surname { get; set; }
    
    	private string _NameWithSurname;
    
    	public string NameWithSurname
    	{
    		get
    		{
    			_NameWithSurname = Name + Surname;
    			return _NameWithSurname;
    		}
    		set {
    			_NameWithSurname = value;
    		}
    	}
    }
    @Html.EditorFor(model => model.Customer.NameWithSurname  , new { htmlAttributes = new { @class = "form-control" } })
