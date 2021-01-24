            MyLogger.Data =  new JavaScriptSerializer().Serialize(Obj);
            MyLogger.OperationType = Operation;
            MyLogger.TableName = typeof(T).Name;
            MyLogger.DateTime = DateTime.Now;
            MyLogger.User_ID = user.Emp_ID;
            MyLogger.IP_Address = myIP;
            db.Loggers.Add(MyLogger);
            Commit();
    
    
        }
