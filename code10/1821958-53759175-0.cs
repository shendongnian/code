        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var nj = new StandardKernel();
            nj.Bind<IVMOne>().To<VMOne>().InTransientScope();  //  <<<<<<<<<<<<<<<
            MainWindow mw = new MainWindow();
            mw.DataContext = nj.Get<MainWindowViewModel>();
            mw.Show();
        }
