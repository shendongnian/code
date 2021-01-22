    public interface IPrinter
    {
       void Print();
    }
    public interface IScreen
    {
       void Print();
    }
    
    public class Document : IScreen,IPrinter
    {
        void IScreen.Print() { ...}
        void IPrinter.Print() { ...} 
    }
    
    .....
    Document d=new Document();
    IScreen i=d;
    IPrinter p=d;
    i.Print();
    p.Print();
    .....
