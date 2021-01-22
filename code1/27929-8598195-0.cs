    <input type="submit" value="Delete" name="onDelete" />
    <input type="submit" value="Save" name="onSave" />
    public ActionResult Practice(MyModel model, string onSave, string onDelete)
    {
    	if (onDelete != null)
    	{
    		// Delete the object
    		...
    		return EmptyResult();
    	}
    
    	// Save the object
    	...
    	return EmptyResult();
    }
