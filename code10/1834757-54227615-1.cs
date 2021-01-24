    public class SomeObject 
    {
        public Inpection Ins {get;set;}
        public Field F {get;set;}
    }
       
    IQueryable<SomeObject> = getInspections.Select(x => new SomeObject { Ins = x.Ins, F = x.F });
