    protected void Page_Load(object sender, EventArgs e)
    {
        employees = (List<Employee>)Session["emp"];
        if(employees == null)
        { 
            employees = new List<Employee>();
        }
        else
        {
            updateListBox();
            int sNum = -1;
            Int32.TryParse(Request.Params["Social"], out sNum);
            if (sNum >= 0)
            {
                lstEmployees.SelectedIndex = sNum;
            }
        }
    }
