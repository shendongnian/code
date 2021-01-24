    var results = from par in dt1.AsEnumerable()
                    join chi in dt2.AsEnumerable()
                      on (int)par["ID"] equals (int)chi["ParentID"]
                    select new //Here you can leave it that way or use your own object.
                               // select new MyResultObject(){prop1 = x, prop2 = y ...}
                    {
                        ParentID = (int)par["ParentID"],
                        ChildID = (int)par["ChildID"],
                    	ColA = (string)par["ColA"],
                    	ColB = (int)par["ColB"],
                    	ColC = (double)chi["ColC"],
                    	ColD = (date)chi["ColD"]
                    };
