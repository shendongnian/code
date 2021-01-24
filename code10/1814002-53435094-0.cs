        private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            if (e.Exception.StackTrace.StartsWith("   at LiveCharts.Geared.GearedValues`1.a.b(ChartPoint A_0)"))
            {
                e.Handled = true;
                return;
            }
            MessageBox.Show(string.Format("{0} - {1}", e.Exception.Message, e.Exception.StackTrace));
        }
        private void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            if (e.Exception.StackTrace.StartsWith("   at LiveCharts.Geared.GearedValues`1.a.b(ChartPoint A_0)"))
            {
                e.Handled = true;
                return;
            }
            MessageBox.Show(string.Format("{0} - {1}", e.Exception.Message, e.Exception.StackTrace));
        }
