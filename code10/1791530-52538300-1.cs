    public class SilentUninstallViewModel
    {
        private BootstrapperApplicationModel model;
        private Engine engine;
        public SilentUninstallViewModel(BootstrapperApplicationModel model, Engine engine)
        {
            this.model = model;
            this.engine = engine;
            WireUpEventHandlers();
        }
        private void WireUpEventHandlers()
        {
            this.model.BootstrapperApplication.PlanComplete += PlanCompleted;
            this.model.BootstrapperApplication.DetectComplete += DetectCompleted;
            this.model.BootstrapperApplication.ApplyComplete += ApplyCompleted;
        }
        private void DetectCompleted(object sender, DetectCompleteEventArgs e)
        {
            this.model.LogMessage("Detecting has been completed for silent uninstallation.");
            this.model.PlanAction(LaunchAction.Uninstall);
        }
        private void ApplyCompleted(object sender, ApplyCompleteEventArgs e)
        {
            this.model.LogMessage("Applying has been completed for silent uninstallation.");
            this.model.FinalResult = e.Status;
            this.engine.Quit(this.model.FinalResult);
        }
        private void PlanCompleted(object sender, PlanCompleteEventArgs e)
        {
            this.model.LogMessage("Planning has been started for silent uninstallation.");
            model.ApplyAction();
        }
    }
