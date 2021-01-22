            using (DataContext db = new DataContext())
            {
                foreach (Item record in db.Items)
                {
                    record.Description += "bla";   
                }
                db.SubmitChanges();
            }
