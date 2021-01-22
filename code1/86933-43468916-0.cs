    public ActionResult History(long id)
            {
                var app = new AppLogic();
                var historyVM = new ActivityHistoryViewModel();
    
                historyVM.ProcessHistory = app.GetActivity(id);
                historyVM.Process = app.GetProcess(id);
                var processlist = app.GetProcessList();
    
                historyVM.ProcessList = from process in processlist
                                        select new SelectListItem
                                        {
                                            Text = process.ProcessName,
                                            Value = process.ID.ToString(),
                                            Selected = long.Equals(process.ID, id)                                    
                                            
                                        };
    
                var listitems = new List<SelectListItem>();
                
                return View(historyVM);
            }
