    public interface Test {
        void DoSomething();
    }
    
    public class TestX : Test {
        void DoSomething() {
        }
    }
    
    public class TestY : Test {
        void DoSomething() {
        }
    }
    
    public class TestZ : Test {
        void DoSomething() {
        }
    }
    
    
    void func(Test test) {
        test.DoSomething();
    }
