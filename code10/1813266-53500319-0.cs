    using System.Diagnostics;
    using System.Web.Mvc;
    using Abp.Domain.Repositories;
    using Abp.EntityFramework.Repositories;
    
    namespace AspNetZero.WebSite.Web.Controllers
    {
        public class MyController : WebSiteControllerBase
        {
            private readonly IRepository<MyEntity> _myEntityRepository;
    
            public MyController(IRepository<MyEntity> myEntityRepository)
            {
                myEntityRepository.GetDbContext().Database.Log = s => Debug.WriteLine(s);
            }
        }
    }
