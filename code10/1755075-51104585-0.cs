    interface IHasUsers
    {
        User[] Users { get; set; }
    }
    class Wanted : CustomClass, IHasUsers
    {
        public User[] Users { get; set; }
        ...
    }
