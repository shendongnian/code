    if (data.HasRows)
    {
    
        while (data.Read())
        {
            Session["userid"] = data["UserID"].ToString();
            Session["typeid"] = data["TypeID"].ToString();
        }
    
        if ((string)Session["typeid"] == "Student")
        {
            return RedirectToAction("Profile");
        }
    
        if ((string)Session["typeid"] == "Tutor")
        {
            return RedirectToAction("TutorProfile");
        }
    
        // HERE
    }
