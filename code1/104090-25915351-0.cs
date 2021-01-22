    // Buttons
    <input name="submit" type="submit" id="submit" value="Save" />
    <input name="process" type="submit" id="process" value="Process" />
    // Controller
    [HttpPost]
    public ActionResult index(FormCollection collection)
    {
        string submitType = "unknown";
 
        if(collection["submit"] != null)
        {
            submitType = "submit";
        }
        else if (collection["process"] != null)
        {
            submitType = "process";
        }
    } // End of the index method
