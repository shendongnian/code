        class ParentClass {
            public virtual void A() {
                Console.WriteLine("ParentClass.A");
            }
        }
    
        class ChildClass : ParentClass {
            public override void A()
            {
                A();
            }
        }
