    public tblCategory Retrieve(int id)
    {
        using (var entities = Context)
        {
            var dto =
                (from t in entities.tblCategory.Include(t => t.tblQuestion)
                                               .Include(t => t.tblQuestion.First().tblAnswer)
                 where t.Id == id
                 select t).FirstOrDefault();
    
            return entities.DetachObjectGraph(dto);
        }
    }
