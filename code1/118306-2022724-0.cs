           using(Journal db = new Journal(con))
           {
              Exercise ne = new Exercise();
 
              ne.Date = Convert.ToDateTime("2009-10-25T14:35:00");
              ne.Length = Convert.ToDouble(3.0);
              ne.Elapsed = "00:53:35";
              db.Exercises.Add(ne);  //add this line to add rec to table
              db.SubmitChanges();
            }
