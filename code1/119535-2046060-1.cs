    using CompanyName.Foo.Models;
    
    namespace CompanyName.Foo {
    	class Test {
    		public Foo Model { get; set; } // error CS0118: 'CompanyName.Foo' is a 'namespace' but is used like a 'type'
    		public Foo1 Model { get; set; } //OK
    	}
    }
    
    namespace CompanyName.Foo.Models {
    	class Foo1 {
    	}
    	class Foo {
    	}
    }
