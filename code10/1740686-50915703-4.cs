    namespace EnvioDocumentos
    {
        static class Program
        {
            /// <summary>
            /// Code bellow is default, never erase
            /// </summary>
            static void Main()
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                { 
                    new EnvioDocs() 
                };
                ServiceBase.Run(ServicesToRun);
           }
        }
    }
