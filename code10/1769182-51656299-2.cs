    public interface ISomeInterface
    {
        string culture { get; set; }
    }
    public class MyClass : ISomeInterface
    object getData<T>() where T : ISomeInterface
    {
       var res = GetCollection<T>().Find(x => x.culture == "ca-ES").ToList();
    
       return res;
    }
