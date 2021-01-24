        using( MyDBContext db = new MyDBContext()){
            var activeEmployees = (from em in db.Employees
                                  join s in db.Store on em.StoreId == s.Id
                                  where em.IsActive == true
                                  select em).ToList();
        }
