    <input type="submit" name="save" value="Save" />
    <input type="submit" name="cancel" value="Cancel" />
    [HttpPost]
    public ActionResult actionname(string save,string cancel)
    {
        string controlClicked = string.empty;
        if(!string.IsNullOrEmpty(save))
        {
            controlClicked  = "save";
        }
        if (!string.IsNullOrEmpty(cancel))
        {
           controlClicked  = "cancel";
        }
        return View();
    }
