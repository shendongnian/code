    [Serializable]
    public class ClassA : IA
    {
        private IB _interfaceB;
        public IB InterfaceB { get { return _interfaceB; } set { _interfaceB = value; } }
    
        public ClassA()
        {
            // Call outside function to get Interface B
            IB interfaceB = Program.GetInsanceForIB();
    
            // Set IB to have A
            interfaceB.SetIA(this);
        }
    }
    
    [Serializable]
    public class ClassB : IB
    {
        private IA _interfaceA;
        public IA InterfaceA { get { return _interfaceA; } set { _interfaceA = value; } }
    
        public void SetIA(IA value)
        {
            this.InterfaceA = value as ClassA;
        }
    }
