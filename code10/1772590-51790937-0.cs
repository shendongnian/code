    public abstract class A {
    
        protected abstract async Task foo(int a);
    
        protected async Task bar(int a) {
            await foo(a);
        }
    }
    
    public class B : A {
        public override async Task foo(int a) {
            return a+1;
        }
    }
