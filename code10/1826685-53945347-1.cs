    public InfoAppointment GetOneByBoatName(string name, 
        Expression<Func<TEntity, bool>> predicate)
    {
      return Boats.First(c => c.Name == name).InfoAppointments.FirstOrDefault(predicate);
    }
