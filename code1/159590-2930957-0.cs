    MyClass myClass = (from MyClassTable mct in this.Context.MyClassTableSet
                            select new MyClass
                            {
                                 ID = mct.ID,
                                 Name = mct.Name,
                                 Things = (from MyOtherClass moc in mct.Stuff
                                           where moc.IsActive
                                           select new MyOtherClass
                                           {
                                                ID = moc.ID,
                                                Value = moc.Value
                                           }).ToList()
                            }).FirstOrDefault();
