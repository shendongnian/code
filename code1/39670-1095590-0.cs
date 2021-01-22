    protected bool HasContent(int chapterID, int institution)
    {
        Database db = new Database();
        int result;
        result = db.ExecuteSpRetVal(chapterID, institution);
        return result > 0;
    }
    
    protected bool HasContent(int chapterID)
    {
        Database db = new Database();
        int result;
        result = db.ExecuteSpRetVal(chapterID);
        return result > 0;
    }
