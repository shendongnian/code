    namespace EnvioDocumentos
    {
        static class Program
        {
            /// <summary>
            /// Punto de entrada principal para la aplicación.
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
