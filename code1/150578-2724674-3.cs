    public virtual JsonResult ActionName(string data)
    {
       // take the data and parse the linear stream... I like to use the FormCollection
       FormCollection collection = new FormCollection();
       foreach (string values in data.Split('&')){
         string[] value = values.Split('=');
         collection.Add(value[0], value[1]);
       }
       // Now do your database logic here
       return Json("Success");
    }
