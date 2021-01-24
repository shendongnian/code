    sealed class EngineCalibration : LaserCalibrationBase<Engine>
    {
        public void Run()
        {
            Console.WriteLine(this.Settings.BladeName); // N/A!
        }
    }
