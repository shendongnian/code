    //using System.Linq;
    public class ABC
    (
        string itemName{get;set;}
        int parentID{get;set;}
        List<ABC> Child {get;set;}    
        public bool AlreadyContains(ABC abc)
        {
            return Child.Any( a => a.Equals(abc) || a.AlreadyContains(abc) ); 
        }
    )
