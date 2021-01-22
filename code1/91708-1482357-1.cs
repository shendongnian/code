    public ExtJSJsonResult View(int id)
    {
        bool success;
        string msg;
        DataRow dr=null;
        try
        {
            dr = DBService.GetRowById("oc.personeller", id);
            success = true;
            msg = "all ok";
        }
        catch (Exception ex)
        {
            success = false;
            msg = ex.Message;
        }
        return new ExtJSJsonResult
        {
            success= success,
            msg = msg,
            Data = dr
        };
        
    }
