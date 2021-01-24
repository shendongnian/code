    string sRedirecttoAction = String.Empty;
    using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
    {
        con.Open();
        string query = @"SELECT UserID, TypeID FROM Users WHERE Email=@Email AND Password=@Password AND Status!=@Status";
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@Email", record.Email);
            cmd.Parameters.AddWithValue("@Password", record.Password);
            cmd.Parameters.AddWithValue("@Status", "Suspended");
            using (SqlDataReader data = cmd.ExecuteReader())
            {
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Session["userid"] = data["UserID"].ToString();
                        Session["typeid"] = data["TypeID"].ToString();
                    }
                    if ((string)Session["typeid"] == "Student")
                        sRedirecttoAction = "Profile";
                    if ((string)Session["typeid"] == "Tutor")
                        sRedirecttoAction = "TutorProfile";
                }
                else
                {
                    ViewBag.Error = "<div class = alert alert-danger col-lg-6'>Invalid Credentials.</div>";
                    return View();
                }
            }
        }
    }
    //return RedirectToAction here.
    return RedirectToAction(sRedirecttoAction);
