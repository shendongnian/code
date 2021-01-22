    partial class Foo
    {
    	partial void foo(Biz.Parameter p);
    }
    
    partial class Foo
    {
    	partial void foo(Baz.Parameter p) { }
    }
    
    namespace Baz
    {
    	class Parameter { }
    }
    
    namespace Biz
    {
    	class Parameter { }
    }
