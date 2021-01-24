                var DBobj = db.AccountsConfigDatas.Find(0);
                var propertyInfo = DBobj.GetType().GetProperty(name); 
                propertyInfo.SetValue(DBobj, NewValue);                
                db.Entry(DBobj).State = EntityState.Modified;
                db.SaveChanges();               
        
