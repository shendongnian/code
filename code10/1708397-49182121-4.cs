    public interface IHasID{
    int Id{get;set;}
    }
    //implement the IHasID interface
    public class User : IHasID...
    
    private IEnumerable<T> ToModels(IEnumerable<int> ints) where T : IHasID, new(){
    foreach(var i in ints){
    yield return new T{Id = i};
    }
    }
