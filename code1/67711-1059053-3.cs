    private void BuildGridView1()
    {
      string[] names = this.txtSearchName.Text.Split(" ".ToCharArray());
      
      SqlQuery query = DB.Select(PastAwardName.Schema.TableName + ".*", PastAwardType.Schema.TableName + ".*")
        .From(PastAwardName.Schema)
        .InnerJoin(PastAwardType.Schema.TableName, PastAwardType.Columns.VolID, PastAwardName.Schema.TableName, PastAwardName.Columns.VolID)
        .Where(PastAwardName.Columns.FName).IsEqualTo(names[0])
      if(names.Length > 1)
        query = query.And(PastAwardName.Columns.LName).IsEqualTo(names[1])
      else
        query = query.Or(PastAwardName.Columns.LName).IsEqualTo(names[0]
  
      GridView1.DataSource = query.OrderAsc(PastAwardType.Columns.AwardYear)
        .ExecuteDataSet();
    }
