    public interface BaseClassFunction {
        void PleaseCallMe();
    }
    public class BaseClass {
        private BaseClassFunction fn;
        public BaseClass(BaseClassFunction fn) {
            this.fn = fn;
        }
        private CallMe() {
            fn.PleaseCallMe();
        }
        public PublicCallMe() {
            CallMe();
        }
    }
    private class DerivedClassFunction : BaseClassFunction {
        void PleaseCallMe() { ... do something important ... }
    }
    public class DerivedClassFunction {
        public DerivedClassFunction() : BaseClass(new DerivedClassFunction()) {
        }
    }
