    if (data.HasRows)
                    {
                        while (data.Read())
                        {
                            Session["userid"] = data["UserID"].ToString();
                            Session["typeid"] = data["TypeID"].ToString();
                        }
                        
                        //make sure there is no space between these two lines
                        if ((string)Session["typeid"] == "Student")
                          return RedirectToAction("Profile");
                        
                        //make sure there is no space between these two lines
                        if ((string)Session["typeid"] == "Tutor")
                            return RedirectToAction("TutorProfile");
                        //###if those two if clauses are not met, there is no return after that.
                        return view(); //? or something else
                    }
