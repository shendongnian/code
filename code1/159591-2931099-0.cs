    var q = (from MyClassTable mct in this.Context.MyClassTableSet
             select new // note anonymous type; important!
             {
                 ID = mct.ID,
                 Name = mct.Name,
                 Things = (from MyOtherClass moc in mct.Stuff
                           where moc.IsActive
                           select new MyOtherClass
                           {
                               ID = moc.ID,
                               Value = moc.Value
                           }
              }).AsEnumerable();
    MyClass myClass = (from mct in q
                       select new MyClass
                       {                 
                           ID = mct.ID,
                           Name = mct.Name,
                           Things = mct.Things.ToList()
                       }).FirstOrDefault();
