    public class BootstrapperApp : BootstrapperApplication
    {
        public static Dispatcher Dispatcher { get; set; }
        protected override void Run()
        {
            Dispatcher = Dispatcher.CurrentDispatcher;
            var model = new BootstrapperApplicationModel(this);
            var command = model.BootstrapperApplication.Command;
            if (command.Action == LaunchAction.Uninstall && (command.Display == Display.None || command.Display == Display.Embedded))
            {
                model.LogMessage("Starting silent uninstaller.");
                var viewModel = new SilentUninstallViewModel(model, Engine);
                Engine.Detect();
            }
            else
            {
                model.LogMessage("Starting installer.");
                var viewModel = new InstallViewModel(model);
                var view = new InstallView(viewModel);
                view.Closed += (sender, e) => Dispatcher.InvokeShutdown();
                model.SetWindowHandle(view);
                Engine.Detect();
                view.Show();
            }
            Dispatcher.Run();
            Engine.Quit(model.FinalResult);
        }}
