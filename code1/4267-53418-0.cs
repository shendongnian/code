    interface IMyObjects : IEnumerable<IOtherObjects> {}
    abstract class MyObjects<T> : IMyObjects where T : IOtherObjects {}
    
    IEnumerable<IMyObjects> objs = ...;
    foreach (IMyObjects mo in objs) {
        foreach (IOtherObjects oo in mo) {
            Console.WriteLine(oo);
        }
    }
