    public class Area()
    public int AreaId {get; set; }
    
    public string AreaDetails { get; set; }
    
    }
    
    public class Departments (){
    public int DepartmentId { get; set; }
    
    public string DepartmentDetails { get; set; }
    
    public List<Area> Areas { get; set; } // all area that are included in the current depertment
    
    }
