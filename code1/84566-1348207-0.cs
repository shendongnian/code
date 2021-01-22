        class Program {
        static void Main(string[] args) {
            A a = new A();
            a.SomeEvent += delegate(object sender, EventArgs e) {
                throw new NotImplementedException();
            };
            a.ClearEventHandlers();
            a.FireEvent();
            Console.WriteLine("No error.");
        }
        public class A {
            public event EventHandler SomeEvent;
            public void ClearEventHandlers() {
                Delegate[] delegates = SomeEvent.GetInvocationList();
                foreach (Delegate @delegate in delegates) {
                    SomeEvent -= (EventHandler) @delegate;
                }
            }
            public void FireEvent() {
                if (SomeEvent != null) {
                    SomeEvent(null, null);
                }
            }
        }
    }
