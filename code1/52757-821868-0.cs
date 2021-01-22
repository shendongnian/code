    public interface IA 
    { 
        IB InterfaceB { get; set; } 
    }
    public interface IB 
    { 
        IA InterfaceA { get; set; } 
        void SetIA(IA value);
    }
    [Serializable]
    public class ClassA : IA
    {    
        public IB InterfaceB { get; set; }    
        public ClassA()    
        {        
            // Call outside function to get Interface B        
            this.InterfaceB = new ClassB();
            // Set IB to have A        
            InterfaceB.SetIA(this);    
        }
    }
    
    [Serializable]
    public class ClassB : IB
    {    
        public IA InterfaceA { get; set; }    
        public void SetIA(IA value)    
        {       
            this.InterfaceA = value;    
        }
    }
    [STAThread]
    static void Main()
    {
        MemoryStream ms = new MemoryStream();
        BinaryFormatter bin = new BinaryFormatter();
        ClassA myA = new ClassA();
        bin.Serialize(ms, myA);
        ms.Position = 0;
        ClassA myOtherA = bin.Deserialize(ms) as ClassA;
        
        Console.ReadLine();
    }
