     var invList = db.Inv.Where(m => m.ID == GI.Id).ToList();
     var invListAcc = invList .Select(m => m.AccNum).ToList();
     var accExtract = db.Acc.Where(m => invListAcc .Contains(m.AccNum)).ToList();
     foreach(var inv in invList)
     {
          var invDB = db.Inv.Find(inv.Id);
          var accCC = accExtract.Where(m => m.AccNum== invDB.AccNum).Select(p=>p.CC).FirstOrDefault();
          if(accCC != null)
          {
               invDB.PCC = accCC;
               db.Entry(invDB).State = EntityState.Modified;
          } 
     }
     db.SaveChanges();
