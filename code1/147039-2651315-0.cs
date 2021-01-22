protected HierarchicalBusinessObject(Action&lt;TModel,string&gt parentSetter);
public class WorkitemBusinessObject :  
    HierarchicalBusinessObject<Workitem,WorkitemDataContext> 
{ 
public WorkitemBusinessObject()  
       : base( (WorkItem w, string s) => {w.Name = s;}) 
    { } 
}
