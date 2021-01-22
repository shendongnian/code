    using (DatabaseDataContext db = new DatabaseDataContext())
            {
                Person p = new Person();
                p.FirstName = "Dario";
                p.LastName = "Iacampo";
    
                Fisherman f = new Fisherman();
                f.FirstName = "San";
                f.LastName = "Pei";
                f.CollectedFishes = 10;
                f.FishingLicenceNumber = "abc";
    
                Driver d = new Driver();
                d.FirstName = "Michael";
                d.LastName = "Shumaker";
                d.CarMake = "Ferrari";
                d.DrivingLicenceNumber = "123abc";
    
                db.BasePeoples.InsertOnSubmit(f);
                db.BasePeoples.InsertOnSubmit(d);
                db.SubmitChanges();
                
            }
