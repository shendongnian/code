    public async Task<JsonResult> Compelete(int id,bool checked)
            {
    
                @using(var ctx = new AssignmentContext())
                {
                var assignment =   ctx.Assignments.Find(id);
                    assignment.Complete = checked;
                    ctx.SaveChanges();
    
    
                }
                return Json(new { isSuccess =true }, JsonRequestBehavior.AllowGet);
            }
