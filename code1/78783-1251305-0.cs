    public class Test{
         public int DoMethod(){ return 2; }
         public string DoMethod() { return "Name"; }
    } 
    Test t;
    int n = t.DoMethod();  // 1st method
    string txt = t.DoMethod(); // 2nd method
    object x = t.DoMethod(); // DOOMED ... which one??
