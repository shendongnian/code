    private void BuildGridView1()
        {
            string[] names = String.Split(this.txtSearchName.Text, ' ');
            if (names.length == 1) {
                GridView1.DataSource = new Select(PastAwardName.Schema.TableName + ".*", PastAwardType.Schema.TableName + ".*")
                  .From(PastAwardName.Schema)
                  .InnerJoin(PastAwardType.Schema.TableName, PastAwardType.Columns.VolID, PastAwardName.Schema.TableName, PastAwardName.Columns.VolID)
                  .Where(PastAwardName.Columns.LName).IsEqualTo(names[0])
                  .Or(PastAwardName.Columns.FName).IsEqualTo(names[0])
                  .OrderAsc(PastAwardType.Columns.AwardYear)
                  .ExecuteDataSet();
            }
            else if (names.Length == 2) {
                GridView1.DataSource = new Select(PastAwardName.Schema.TableName + ".*", PastAwardType.Schema.TableName + ".*")
                  .From(PastAwardName.Schema)
                  .InnerJoin(PastAwardType.Schema.TableName, PastAwardType.Columns.VolID, PastAwardName.Schema.TableName, PastAwardName.Columns.VolID)
                  .Where(PastAwardName.Columns.LName).IsEqualTo(names[1])
                  .And(PastAwardName.Columns.FName).IsEqualTo(names[0])
                  .OrderAsc(PastAwardType.Columns.AwardYear)
                  .ExecuteDataSet();
            }
        }
