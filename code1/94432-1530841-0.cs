    interface IMyControl {
        void A();
    }
    class MyHelperControl : IMyControl {
        void A() {
            // your implementation here
        }
    }
    class MyControl : Control, IMyControl {
        private MyHelperControl _myHelper;
        void A() {
            _myHelper.A();
        }
    }
    class MyForm : Form, IMyControl {
        private MyHelperControl _myHelper;
        void A() {
            _myHelper.A();
        }
    }
