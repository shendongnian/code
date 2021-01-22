     public class FactoryMethodUnityExtension<T> : UnityContainerExtension
     {
         private Func<Type,T> factory; 
 
         public FactoryMethodUnityExtension(Func<Type,T> factory)
         {
             this.factory = factory;
         }
 
         protected override void Initialize()
         {
             var strategy = new CustomFactoryBuildStrategy<T>(factory, this.Context);
             Context.Strategies.Add(strategy, UnityBuildStage.PreCreation);             
         }
     } 
     public class CustomFactoryBuildStrategy<T> : BuilderStrategy
     {
         private Func<Type,T> factory;
         private ExtensionContext baseContext;
 
         public CustomFactoryBuildStrategy(Func<Type,T> factory, ExtensionContext baseContext)
         {
            this.factory = factory;
            this.baseContext = baseContext;
         }
 
         public override void PreBuildUp(IBuilderContext context)
         {
             var key = (NamedTypeBuildKey)context.OriginalBuildKey;
 
             if (key.Type.IsInterface && typeof(T).IsAssignableFrom(key.Type))
             {
                 object existing = baseContext.Locator.Get(key.Type);
                 if (existing == null)
                 {
                     // create it
                     context.Existing = factory(key.Type);
                     // cache it
                     baseContext.Locator.Add(key.Type, context.Existing);
                 }
                 else
                 {
                     context.Existing = existing;
                 }
             }
         }
     }
