    interface IRepositorySet<Tentity> : IEnumerable<Tentity>
         where Tentity : class, new()
    {
         Tentity Add(Tentity entity);
         Tentity Update(Tentity entity);
         Tentity Delete(Tentity entity);
    }
    interface ISchoolsRepository
    {
         // for simple queries / add / update / remove only
         IRepositorySet<School> Schools {get;}
         IRepositorySet<Teacher> Teachers {get;}
         IRepositorySet<Student> Students {get;}
    }
