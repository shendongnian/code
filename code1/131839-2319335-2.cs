public class SomeClass{
    private readonly objLock = new object();
    ....
    public object SomeProperty{
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
