    namespace A1
    {
        namespace A2  // A1.A2
        {
            class C2  // full name: A1.A2.C2
            {
                private A1.C1 c1b;   // full name 
                private C1 c1b;      // shortest form. A1 is in scope here
            }
        }
    
        class C1   // full name: A1.C1
        {
            private A1.A2.C2 c2a;   // full name
            private A2.C2 c2b;      // shortest form. We can omit the A1 prefix but not A2
        }
    }
