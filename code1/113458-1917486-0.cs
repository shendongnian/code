    public class SimulationForm
    {
        public Action Init { get; set; }
        public Action<Graphics> Render { get; set; }
        public Action<double> Move { get; set; }
        //...
    }
