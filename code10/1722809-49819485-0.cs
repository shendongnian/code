    public bool updatePerson(Person p)
    {
      try
        {
          var ctx = GetAppControlContext();
          //if it exists then we can change the state to modified
          if (ctx.People.Any(ps => ps.Id == p.Id))
          {
            //This will attach the entity to the context
            //Will also mark it so it will be saved in SaveChanges();
            ctx.Entry(p).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
            Console.WriteLine("person updated");
            return true;
          }
   
        }catch (Exception ex)
        {
          Console.WriteLine(ex.ToString());
          return false;
        }
      return false;
    }
