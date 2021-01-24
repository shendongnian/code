    public class SomeObject 
    {
        public Inpection Ins {get;set;}
        public Field F {get;set;}
    }
       
    IQuerable<SomeObject> = getInspections.Select(x => new SomeObject { Ins = x.Ins, F = x.F });
