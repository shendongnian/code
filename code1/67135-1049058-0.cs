    public interface IHasName1
    {
        String Name1 { get; set; }
    }
    public interface IHasName2 : IHasName1
    {
        String Name2 { get; set; }
    }
