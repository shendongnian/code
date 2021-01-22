    var myId = A.BOrNull().COrNull().IdOrNull();
    public class A {
        public B B { get; set; }
    }
    public static class AExtensionMethods {
        public static B BOrNull( this A a ) {
            return null != a ? a.B : null;
        }
    }
    
    public class B {
        public C C { get; set; }
    }
    public static class BExtensionMethods {
        public static C COrNull( this B b ) {
            return null != b ? b.C : null;
        }
    }
    
    public class C {
        public int Id { get; set; }
    }
    public static class CExtensionMethods {
        public static int? IdOrNull( this C c ) {
            return null != c ? (int?)c.Id : null;
        }
    }
