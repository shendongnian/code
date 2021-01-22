    public CustomerView(Customer customer)
    {
          this.FirstName = customer.FirstName
          //etc..
          //Only if you need it, that is if you have some display-specific
          //logic relating to country for a given view, you create
          //a CountryView class that inherits from Country and gets populated
          //by an instance of it as well
          this.CountryView = new CountryView(customer.Country)
    }
    public CountryView CountryView {get;set;} //sadly you cannot override Country but you may be able to shadow it.
 
    public string DisplayColor
    {
        if(base.FirstName == "Joe")
        {
            return "red";
        }
        return "";
    }
