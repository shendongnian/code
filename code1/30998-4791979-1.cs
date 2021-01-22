    static void Main(string[] args) {
    
               DatabaseCodeDelegate slave = DatabaseCode;
               slave ("test");
    
    }
    
    public void DatabaseCode(string arg) {
    
               .... code here ...
    
    }
    public delegate void DatabaseCodeDelegate(string arg);
