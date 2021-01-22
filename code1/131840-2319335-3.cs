public static class SomeClass{
    private static object objLock = new object();
    ....
    public static object SomeProperty{
       get{ 
           lock(objLock){
             // Do whatever needs to be done
           }
       }
       set{
           lock(objLock){
           }
       }
    }
}
