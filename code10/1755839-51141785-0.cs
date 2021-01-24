    public string Delete(this BaseObject theObject)
    {
        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
        {
            db.Delete(theObject);
        }
    }
