    public interface ISimulationRunner {
        public int MaxStepCount { get; set; }
        ...
        public void Run() {...}
        public void Step() {...}
        public void Stop() {...}
    }
    
    public class SimulationRunner<TSpace, TCell> : ISimulationRunner 
        where TSpace : I2DState<TCell>
        where TCell : Cell
    {
        public TSpace InitialState { get; set; }
        public IStepAlgorithm<TSpace,TCell> StepAlgorithm { get; set; }
        public IDisplayStateAlgorithm<TSpace,TCell> DisplayStateAlgorithm { get; set; }
    }
    public partial class UI : Window
    {
      ISimulationRunner simulation = new SimulationRunner<2DSpace, SimpleCell>();
      private void mnuiSimulate_Click(object sender, RoutedEventArgs e)
      {
        if (simulation != null) simulation.RunSimulation();
      }
    }
