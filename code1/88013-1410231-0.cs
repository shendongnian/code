    public class MyClass {
    
    public int iMyStatusProperty { get; set; }
    public int iMyKey { get; set; }
    
    public int UpdateStatusProperty(int iValue){
    this.iMyStatusProperty = iValue;
    return _Update( new[iMyStatusProperty ], iMyKey); // this should generate SQL: "UPDATE MyClass set iMyStatusProperty = {iMyStatusProperty} where iMyKey = {iMyKey}"
    }
