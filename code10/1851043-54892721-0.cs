        public class buttonTestComponent : GH_Component
        {    
             private Attributes_Custom m_attributes;
             public override void CreateAttributes()
             {
                 m_attributes = new Attributes_Custom(this);
             }
        
             protected override void SolveInstance(IGH_DataAccess DA)
             {
                 Circle circle = new Circle(2.00);
                //use m_attributes.Bake here
             }
        }
