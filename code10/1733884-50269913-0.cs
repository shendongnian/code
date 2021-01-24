    [HttpPost]
    public ActionResult Index(FormData person)
    {
     FormData Detail = new FormData();
     Detail.PlantName = PopulatePlant(person.EmpId.ToString()); //pass the relevant value to the method (using TempData is not really needed here)
     return View("MasterPage");
    }
    
    private static List<SelectListItem> PopulatePlant(string empId) //declare that the method will receive a string parameter
    {
        List<SelectListItem> PName = new List<SelectListItem>();
        String connectionString = ConfigurationManager.ConnectionStrings["conndbprodnew"].ConnectionString;
        OracleConnection connection = new OracleConnection(connectionString);
        OracleCommand command = new OracleCommand("select nvl(count(1),0) from Tdc_Product1 where TDC_NO=:COLUMN1", connection);
        command.CommandType = CommandType.Text;
        command.Parameters.AddWithValue(":COLUMN1", empId); //use the method's parameter
        return PName;
    }
