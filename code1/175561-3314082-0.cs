    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main( string[] args )
            {
                // Create some business objects and ask them to initialize
                // themselves.
                //
    
                var bo1 = new BusinessObject1();
                var bo2 = new BusinessObject2();
    
                bo1.Fill();
                bo2.Fill();
            }
    
            public abstract class BusinessObjectBase
            {
                public int x { get; private set; }
    
                public virtual void Fill()
                {
                    x = 123;
                }
            }
    
            public class BusinessObject1 : BusinessObjectBase
            {
                public int y { get; private set; }
    
                public override void Fill()
                {
                    // Let base class fill itself.
                    base.Fill();
    
                    // Now we fill our own properties.
                    this.y = 456;
                }
            }
    
            public class BusinessObject2 : BusinessObjectBase
            {
                public int z { get; private set; }
    
                public override void Fill()
                {
                    // Let base class fill itself.
                    base.Fill();
    
                    // Now we fill our own properties.
                    this.z = 456;
                }
            }
        }
    }
