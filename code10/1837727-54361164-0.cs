    var dif = new DataInterfaceFactory(DatabaseTypes.SqlServer, "WDM_SOFTWARE_INFO", "d2sql4.d2.wdm");
    
                    using (DataReader dr = dif.GetDataReader())
                    {
                        dr.ExecuteReader("SELECT COUNT(1) AS TABLECOUNT FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CALCULATION_SCHEDULE'");
    
                        while (dr.Read())
                        {
                            var exists = Convert.ToInt32(dr["TABLECOUNT"]);
    
                            if (exists == 0)
                                
                            {                                
                                TableBuilder calculationSchedule = new TableBuilder("CALCULATION_SCHEDULE", dif.DatabaseType);
                                calculationSchedule.AddField("CALCULATION_SCHEDULE_UID", DbFieldType.int_, 0, false, null, true, null);
                                calculationSchedule.AddField("SERVER_NAME", DbFieldType.nvarchar_);
                                calculationSchedule.AddField("DATABASE_NAME", DbFieldType.nvarchar_);
                                calculationSchedule.AddField("LAST_CHECK_DATE", DbFieldType.datetime_);
                                calculationSchedule.AddField("IS_RUNNING", DbFieldType.int_);
    
                                using (CommandExecutor cex = dif.GetCommandExecutor())
                                {
                                    calculationSchedule.BuildTable(cex);
                                }
                            }
                         }
                     }
                  }
