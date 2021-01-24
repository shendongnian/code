     [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestID,EmployeeID,StartDate,FinishDate,HoursTaken,Comments,YearCreated,MonthCreated,DayCreated,YearOfHoliday,Approved,SubmittedBy,ApprovedBy")] HolidayRequestForm holidayRequestForm)
        {
            if (ModelState.IsValid)
            {
                if (Session["Name"] == null)
                {
                    TempData["msg"] = "Your Session Expired - Please Login";
                    return RedirectToAction("Login", "Account");
                }
                string name = Session["Name"].ToString();
                var approvedby = db.Employees.Where(s => s.Email.Equals(name)).Select(s => s.Email).FirstOrDefault();
                holidayRequestForm.ApprovedBy = approvedby;
                db.Entry(holidayRequestForm).State = EntityState.Modified;
                db.SaveChanges();
               
               
                
                if ( holidayRequestForm.Approved == true){
                    SendMailToAreaManager();
                    SendMailToManager();
                    SendMailToAdmin();
                }
