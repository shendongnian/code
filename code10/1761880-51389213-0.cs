    public List<tbl> SearchNewsByTitle(string title, int groupid)
    {
        try
        {
            var result = from n in tbl   
                         where (n.GroupId == (groupid < 0 ? n.GroupId : groupId))
                         select n;
    
            return result.ToList();
        }
        catch (Exception e)
        {
            AddExceptionData(e);
            return null;
        }
    
    }
    
    public List<tbl> SearchNewsByTitle(string title) 
    {
    	return SearchNewsByTitle(title, -1);
    }
