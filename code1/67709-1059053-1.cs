    private void BuildGridView1()
    {
      string names[] = this.txtSearchName.Text.Split(" ".ToCharArray());
      
      SqlQuery query = DB.Select(PastAwardName.Schema.TableName + ".*", PastAwardType.Schema.TableName + ".*")
        .From(PastAwardName.Schema)
        .InnerJoin(PastAwardType.Schema.TableName, PastAwardType.Columns.VolID, PastAwardName.Schema.TableName, PastAwardName.Columns.VolID)
        .Where(PastAwardName.Columns.FName).IsEqualTo(this.txtSearchName.Text)
      if(names.Length > 1)
        query = query.And(PastAwardName.Columns.LName).IsEqualTo(this.txtSearchName.Text)
      else
        query = query.Or(PastAwardName.Columns.LName).IsEqualTo(this.txtSearchName.Text)
  
      GridView1.DataSource = query.OrderAsc(PastAwardType.Columns.AwardYear)
        .ExecuteDataSet();
    }
