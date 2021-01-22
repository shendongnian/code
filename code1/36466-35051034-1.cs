    using System;
    using System.ServiceModel;
    using MyApp.MyService; // The name you gave the service namespace
    
    namespace MyApp.Helpers.Services
    {
        public class MyServiceClientSafe : MyServiceClient, IDisposable
        {
            void IDisposable.Dispose()
            {
                if (State == CommunicationState.Faulted)
                {
                    Abort();
                }
                else if (State != CommunicationState.Closed)
                {
                    Close();
                }
                // Further error checks and disposal logic as desired..
            }
        }
    }
