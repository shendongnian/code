        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult updatecomponents(StaffEntryUpdateModel postedData)
        {
            try
            {
                if (postedData.StaffComponents.Any())
                {
                    ApplicationUser Staff = db.Users.FirstOrDefault(s => s.Id == postedData.StaffId);
                    if (Staff == null)
                    {
                        return new JsonResult(new { Status = false, Message = "Unknown staff" });
                    }
                    db.StaffEntries.Where(se => se.StaffId == postedData.StaffId).Delete();
                    foreach (var c in postedData.StaffComponents)
                    {
                        db.StaffEntries.Add(c);
                    }
                    int inserted = db.SaveChanges();
                    return new JsonResult(new { Status = (inserted > 0) ? true : false, Message = inserted + " components updated for staff" });
                }
                else
                {
                    return new JsonResult(new { Status = false, Message = "No component sent for update for staff" });
                }
            }
            catch (Exception e)
            {
                return new JsonResult(new {Status=false,Message=e.Message.ToString() });
            }
        }
