                //Table's Name is Efforts,
                //Column's name is Target
                //Create an Adaptor
                EffortsTableAdapter ad = new EffortsTableAdapter();
                ProjectDashBoard.Db.EffortsDataTable efforts = ad.GetData();
                DataColumn targetColumn = new DataColumn();
                targetColumn = efforts.TargetColumn;
                List<DateTime?> targetTime = new List<DateTime?>();
                foreach (var item in efforts)
                {
                    DateTime? myDateTime = item.IsTargetNull() ? null : (DateTime?)item.Target;
                    targetTime.Add(myDateTime);
                    
                }
