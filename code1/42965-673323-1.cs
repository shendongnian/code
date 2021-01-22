    public class Parameter
    {
        public string P1 { get; set; }
        public int P2 { get; set; }
        public string P3 { get; set; }
        public double P4 { get; set; }
        ...
        public Parameter()
        {
            P1 = "p1";
            P2 = 2;
            P3 = "p3";
            P4 = 4.0;
            ...
        }
    }
    ...
    FunctionWithManyParametersCanNowBeCalledLike(new Parameter() { P2 = -2 });
