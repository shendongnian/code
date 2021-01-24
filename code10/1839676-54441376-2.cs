    public class ContextFactory : IContextFactory {
    
      _anotherProcessor = anotherProcessor;
     public ContextFactory(IAnotherProcessor anotherProcessor) {
         //you can leverage DI here to get dependancies
     }
    
     public IContext Create(){
        Context factoryCreatedContext = new Context();
       
        factoryCreatedContext.SomethingProcessor = new SomethingProcessor(factoryCreatedContext )
        factoryCreatedContext.AnotherProcessor = _anotherProcessor;
        
        //You can even decide here to use other implementation based on some dependencies. Useful for things like feature flags.. etc.
        return context;
      }
      
    }
