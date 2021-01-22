    static public class ConsoleView
    {
        //DEFINICIONES DE LA CLASE
        #region DEFINICIONES DE LA CLASE
        static FrmConsole console;
        static Thread StatusThread;
        static bool isActive = false;
        #endregion
        //CONSTRUCTORES DE LA CLASE
        #region CONSTRUCTORES DE LA CLASE
        #endregion
        //PROPIEDADES
        #region PROPIEDADES
        #endregion
        //DELEGADOS
        #region DELEGADOS
        #endregion
        //METODOS Y FUNCIONES
        #region METODOS Y FUNCIONES
        public static void Show(string label)
        {
            if (isActive)
            {
                return;
            }
            isActive = true;
            //create the thread with its ThreadStart method
            StatusThread = new Thread(() =>
            {
                try
                {
                    console = new FrmConsole(label);
                    console.ShowDialog();
                    //this call is needed so the thread remains open until the dispatcher is closed
                    Dispatcher.Run();
                }
                catch (Exception)
                {
                }
            });
            //run the thread in STA mode to make it work correctly
            StatusThread.SetApartmentState(ApartmentState.STA);
            StatusThread.Priority = ThreadPriority.Normal;
            StatusThread.Start();
        }
        public static void Close()
        {
            isActive = false;
            if (console != null)
            {
                //need to use the dispatcher to call the Close method, because the window is created in another thread, and this method is called by the main thread
                console.Dispatcher.InvokeShutdown();
                console = null;
                StatusThread = null;
            }
            console = null;
        }
        public static void Release()
        {
            isActive = false;
            if (console != null)
            {
                console.Dispatcher.Invoke(console.ActivarCerrar);
            }
        }
        #endregion
    }
