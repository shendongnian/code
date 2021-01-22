    public interface ITest
    {
        void M1();
        string M2(int m2, string n2);
        string prop { get; set; }
        
        event test BoopBooped;
    }
    Type it = GenerateInterfaceImplementation<ITest>();
    ITest instance = (ITest)Activator.CreateInstance(it,
        new Action(() => {Console.WriteLine("M1 called"); return;}),
        new Func<int, string, string>((i, s) => "M2 gives " + s + i.ToString()),
        new Func<String>(() => "prop value"),
        new Action<string>(s => {Console.WriteLine("prop set to " + s);}),
        new Action<test>(eh => {Console.WriteLine(eh("handler added"));}),
        new Action<test>(eh => {Console.WriteLine(eh("handler removed"));}));
    // or with the generated DLL
    ITest instance = new DynamicITestWrapper(
        // parameters as before but you can see the signature
        );
