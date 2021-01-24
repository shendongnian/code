    public interface IBaseService<out TVM> where TVM : IBaseVM
    {
        TVM Method1();
        void Method2(IBaseVM param);
    }
    public interface IBaseVM
    {
        int Id { get; set; }
        string Name { get; set; }
    }
    public class Child1VM : IBaseVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Child1Service : IBaseService<Child1VM>
    {
        public Child1VM Method1() { return new Child1VM(); }
        public void Method2(IBaseVM param)
        {
            return; //body... }
        }
    }
    public class Driver
    {
        public static void Main(string[] ars)
        {
            IBaseService<Child1VM> child1Service = new Child1Service();
            IBaseService<IBaseVM>[] services = new IBaseService<IBaseVM>[]
                {
                    child1Service,
                };
        }
    }
