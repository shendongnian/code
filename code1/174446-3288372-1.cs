    class MyServiceImpl : IMyService
    {
        public List<Foo> All()
        {
           // TODO
        }
        [PrincipalPermission(SecurityAction.Demand, Role ="Administrator")]
        public List<Foo> AllAdmin()
        {
           // TODO
        }
    }
