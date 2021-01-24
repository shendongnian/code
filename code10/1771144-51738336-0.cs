    // Get list object
    public List<GradeSheetViewModel> Show(int id)
    {
        return _repGrade.GetList(id);
    }
    
    // Controller
    public ActionResult ExportToExcel(int id)
    {
        var gv = new GridView();
        gv.DataSource = Show(id);
    
        // other stuff
    }
