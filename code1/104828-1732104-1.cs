    <input type="submit" name="submitButton" value="Save" />
    <input type="submit" name="submitButton" value="SaveAndCopy" />
    public ActionResult Save( string submitButton, ... )
    {
         if (submitButton == "Save")
         {
            ...
         }
         else if (submitButton == "SaveAndCopy")
         {
            ...
         }
         ....
    }
