    public abstract class ObjBase
       {
       }
       
    internal interface IDatabaseObject
       {
       }
      
    public class Obj : ObjBase, IDatabaseObject
       {
       }
    
      
    internal interface IDatabaseObjectManager
       {
          List<ObjBase> getSomeStuff();
       }
    
    public class ObjManager : IObjManager
    {
        public List<Obj> returnStuff()
        {
           return getSomeStuff().Cast <Customer>().ToList<Customer>();
        }
        
        private List<ObjBase> getSomeStuff()
        {
           return new List<ObjBase>();
        }
    }
    
