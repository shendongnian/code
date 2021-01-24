    public IActionResult GetMessages()
    {
        var messages = new StringBuilder();
       
        messages.Append(RunBatch());
        messages.Append("\n"); // use newline to separate messages from different methods
        messages.Append(ProcessAdjustedBatch());
    
        return Json(messages.ToString(), JsonRequestBehavior.AllowGet);
    }
    
