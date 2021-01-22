    public class DomainObject{
    private string nnp;
    protected DomainObject(){}
    public DomainObject(string nnp){
    this.nnp = nnp;
    }
    public string NotNullProp {get {return nnp;}}
    public string NullableProp {get;set;} 
    }
