    public ActionResult Add_session()
    {
        var result =(from a in db.Session_details_feedback
                    join b in db.Employee_Details_Feedback on a.Trainer_id equals b.Emp_id
                    select new Add_session_ViewModel   //<= Note here
                    {
                         Session_date = a.Session_date,
                         Session_name = a.Session_name,
                         emp_name = b.Emp_name
                    }).ToList();       
    
        return View(result);    //<= Return result to view instead of "ViewData"
    }
    
