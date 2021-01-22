    class Outer {
        // don't pass this reference outside of Outer
        private static readonly object token = new object();
    
        public sealed class Inner {
            // .ctor demands proof of who the caller is
            internal Inner(object token) {
                if (token != Outer.token) {
                    throw new InvalidOperationException(
                        "Seriously, don't do that! Or I'll tell!");
                }
                // ...
            } 
        }
    
        // the outer-class is allowed to create instances...
        private static Inner Create() {
            return new Inner(token);
        }
    }
