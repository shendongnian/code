        class ParentClass {
            public virtual void A() {
                // Some operations
            }
        }
    
        class ChildClass : ParentClass {
            public override void A()
            {
                base.A();
            }
        }
