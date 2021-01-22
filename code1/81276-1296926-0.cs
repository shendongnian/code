    public class CBaseGroup<T> where T : IRenderable
    {
     private List<T> CCollection;
    
     public CBaseGroup(List<T> c)
     {
       CCollection=c;
     }
    }
    public class CGroup:CBaseGroup<CBase>
    {
     public CGroup(List<CBase> c):base(c) 
     {
     }
    }
