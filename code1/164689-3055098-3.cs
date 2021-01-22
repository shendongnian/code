    public class MyCustomControl
    {
        private MyCommonControlBehaviors common; // Composition
        public Whatever Read() { return this.common.Read(); }
        public void Alert() { this.common.Alert(); }
    }
