       private IQueryable<Family> GetFamilys()
        {
            return Master.Connection.Familys;
        }
        private IQueryable<Car> GetCars()
        {
             return Master.Connection.Cars;
        }
        
        public List<Families> FillFamilies()
        {
          var list = (from family in GetFamilys()
                       join car in GetCars() on family.ID equals car.familyID
                       select new Families
                      {
                       Id = family.ID,
                       Surname = family.Surname,
                       Address = family.Address,
                       Cars = car.Name
                      }).ToList();
           return list;
         }
