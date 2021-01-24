    public ActionResult ViewProfile()
    {
    	if(Session["UserID"] != null)
        {
            using (The_PizzatoriumEntities1 db = new The_PizzatoriumEntities1())
            {
    			int userId = Convert.ToInt32(Session["UserID"].ToString());
    			
                var userDetails = db.tblUsers.Where(x => x.dID == userId).FirstOrDefault();
                if (userDetails != null)
                {
                    return View(userDetails);
                }
            }
        }
    	
    	return RedirectToAction("Login", "Account"); // Redirect to your login page
    }
