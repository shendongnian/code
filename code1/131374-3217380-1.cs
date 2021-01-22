        private void DoGroupCall()
        {
            uint count = 5;
            GroupAction action = new GroupAction(count,
                () =>
                {
                    MessageBox.Show("Finished All Tasks");
                });
            for (uint i = 0; i < count; i++)
            {
                TempConvertHttpPost proxy = new TempConvertHttpPostClient(new BasicHttpBinding(), new EndpointAddress("http://localhost/webservices/tempconvert.asmx"));
                CelsiusToFahrenheitRequest request = new CelsiusToFahrenheitRequest() { Celsius = "100" };
                proxy.BeginCelsiusToFahrenheit(request,
                      (ar) => Deployment.Current.Dispatcher.BeginInvoke(
                          () =>
                          {
                              CelsiusToFahrenheitResponse response = proxy.EndCelsiusToFahrenheit(ar);
                              // Other code presumably...
                              action.SingleActionComplete();
                          }
                      ), null);
            }
        }
