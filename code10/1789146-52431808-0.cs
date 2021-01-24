    public class Customer 
     {
    	 public int Id { get; set; }
    	 public string Name { get; set; }
    	 public string Surname { get; set; }
    	 public string NameWithSurname 
    	 {
    		 get{
    		     return Name + Surname;
    		 }
    	 }
     }
    @Html.EditorFor(model => model.Customer.NameWithSurname  , new { htmlAttributes = new { @class = "form-control" } })
