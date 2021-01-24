    public abstract class A {
    
        public abstract Task<int> foo(int a);
    
        protected async Task bar(int a) {
            await foo(a);
        }
    }
    
    public class B : A {
        public override async Task<int> foo(int a) {
            return a + 1;
        }
    }
