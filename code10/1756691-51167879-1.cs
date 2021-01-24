    public bool SaveMethodInDataBase(MyDataModel myDataModel)
    {
         MyDataModel result = _dbContext.MyDataModel.Add(myDataModel);
         _dbContext.SaveChanges();
    }
