    class Global
    {
        BeginRequest()
        {
            servicelocater.get<unitofwork>().start();
        }
        EndRequest()
        {
            var unit = servicelocater.Get<Unitofwork>();
            try
            {
                unit.commit();
            }
            catch
            {
                unit.rollback();
                throw;
            }
        }
    }
    
    class Repository<T>
    {
         public Repository(INHibernateUnitofwork unitofwork)
         {
             this.unitofwork = unitofwork;
         }
         
         public void Add(T entity)
         {
             unitofwork.session.save(entity);
         }
    }
