    public static Document[] GetFavouriteDocumentsForProject(int projectId)
    {
        using (var db = new MyContext())
        {
            return
                (from favourite in db.FavouriteDocuments
                where favourite.ProjectID == projectId
                select favourite.Document).ToArray();
        }
    }
