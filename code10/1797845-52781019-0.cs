    class Simulator
    {
        private Engine engine = new Engine();
        private Transmission transmission;
        CarKey carKey;
         
        //public ObservableCollection<string> FanSays { get { return fan.FanSays; } }
        //public ObservableCollection<string> PitcherSays { get { return pitcher.PitcherSays; } }
       // public int Trajectory { get; set; }
        //public int Distance { get; set; }
        public Simulator()
        {
            transmission = new Transmission(engine);
            carKey = engine.GetNewKey();
        }
        public async void StartSimulator()
        {
            EngineEventArgs engineEventArgs = new EngineEventArgs("America!");
            await new MessageDialog("made it inside the start method").ShowAsync();
            
            carKey.StartTheEngine(engineEventArgs);
        }
    }
