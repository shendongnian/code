    abstract class BaseTest{
    
     @Test
     public void featureX(){
        Type t = createInstance();
        // do something with t
     }
     
     abstract Type createInstance();
    }
    
    ConcreteTest extends BaseTest{
    
        Type createInstace(){
            return //instantiate concrete type here.
        }
    }
