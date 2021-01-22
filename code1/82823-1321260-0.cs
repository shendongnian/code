                using (advWorksDataContext dc = new advWorksDataContext())
            {
                Employees emp = dc.Employees.FirstOrDefault();
                dc.MakeDirty(emp);
                dc.SubmitChanges();
            }
