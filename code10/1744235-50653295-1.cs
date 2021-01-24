    //using System.Linq;
    public class ABC
    (
        string itemName{get;set;}
        int parentID{get;set;}
        List<ABC> Child {get;set;}    
        public bool AlreadyContains(ABC abc)
        {
            if (Child.Any( a => a.itemName == abc.itemName )) return true;  //Check children
            return Child.Any( a => a.AlreadyContains(abc) );   //Ask children to check their children too
        }
    )
