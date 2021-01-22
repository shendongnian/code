    public class B : A {
        public void DoSomething(MyForm form) {
            form.MyLabel.Text = "I'm a B object!";
        }
    }
    public class C : A {
        public void DoSomething(MyForm form) {
            form.MyLabel.Text = "I'm a C object!";
        }
    }
    // elsewhere, in a method of MyForm:
    A foo = GetA();
    foo.DoSomething(this);
