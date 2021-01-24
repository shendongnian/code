    [HttpPost]
    public IActionResult PickAlert(int? SelectedAlertIndex)
    {
        var model = new EdxlCapMessageViewModel(/* ... params, if any */);
        
        if (SelectedAlertIndex.HasValue)
        {
            ViewBag.Message = "Alert loaded successfully";
            var selectedAlert = _context.Alert.FirstOrDefault(x => x.AlertIndex == SelectedAlertIndex);            
            // I added a property to your model to store the alert; 
            // if you already have one, just use that one instead.
            model.SelectedAlert = selectedAlert;    
        }
        return View("YourViewName", model);
    }
