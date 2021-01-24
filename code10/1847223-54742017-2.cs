    public ActionResult Add_session()
    {
        Add_session_ViewModel model = new Add_session_ViewModel(); 
        var result =(from a in db.Session_details_feedback
                    join b in db.Employee_Details_Feedback on a.Trainer_id equals b.Emp_id
                    select new Add_session_ViewModel   //<= Note here
                    {
                         Session_date = a.Session_date,
                         Session_name = a.Session_name,
                         emp_name = b.Emp_name
                    }).ToList(); 
    
        model.Session_List = result;      
    
        return View(model);    //<= Return model to view instead of "ViewData"
    }
    
