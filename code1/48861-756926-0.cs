    using System;
    using System.Collections.Generic;
    
    class Foo { public void Do() { /*...*/ } /*...*/ }
    class Bar : Foo { 
        new public static void Do() 
        { ((Foo)new Bar()).Do();/*...*/ } /*...*/ 
    }
