    namespace CompanyName {
    	using CompanyName; //<--using1 - Implicit using, since we should be able to access anything within CompanyName implicitly.
    	namespace Foo {
    		using CompanyName.Foo; //<-- using2 Same as above
    		class Test {
    			public Foo Model { get; set; } //At this stage due to using1 Foo is actually CompanyName.Foo, hence the compiler error
    		}
    	}
    }
