                //Table's Name is Efforts,
                //Column's name is Target
                //So the dataset would automatically generate a property called IsTargetNull() which can be used to check nullables
                //Create an Adaptor
                EffortsTableAdapter ad = new EffortsTableAdapter();
                ProjectDashBoard.Db.EffortsDataTable efforts = ad.GetData();
                DataColumn targetColumn = new DataColumn();
                targetColumn = efforts.TargetColumn;
                List<DateTime?> targetTime = new List<DateTime?>();
                foreach (var item in efforts)
                {
                    //----------------------------------------------------
                    //This is the line that we are discussing about : 
                    DateTime? myDateTime = item.IsTargetNull() ? null : (DateTime?)item.Target;
                    //----------------------------------------------------
                    targetTime.Add(myDateTime);
                    
                }
