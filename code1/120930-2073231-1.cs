    interface IControl
    {
        void Paint();
    }
    class Control: IControl
    {
        void IControl.Paint() {…}
    }
    class MyControl: Control, IControl
    {
        public void Paint() {}
    }
