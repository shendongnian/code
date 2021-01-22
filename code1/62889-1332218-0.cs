    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //// How many test windows do we need to create.
            int numberOfClients = 5;
            System.Threading.Thread[] threads = 
                new System.Threading.Thread[numberOfClients];
            //// Create threads for each of the windows, and then start them.
            for (int i = 0; i < numberOfClients; i++)
            {
                threads[i] = new System.Threading.Thread(Program.StartTest);
                threads[i].SetApartmentState(System.Threading.ApartmentState.STA);
                //// Passing in the startup parameters for each each instance.
                threads[i].Start(new StartupParameters(i));
            }
            //// This will keep the application running until 
            ////  all the windows are closed.
            foreach (System.Threading.Thread thread in threads)
            {
                thread.Join();
            }
        }
        /// <summary>
        /// Starts the test form.
        /// </summary>
        /// <param name="state">
        /// The state object containing our startup parameters.
        /// </param>
        private static void StartTest(object state)
        {
            StartupParameters parameters = state as StartupParameters;
            YourTestForm yourTestForm = new YourTestForm();
            //// Set the needed parameters before we run the form.  
            //// Add your parameters here.
            yourTestForm.Text = string.Format("Test form {0}", parameters.Index);
            //// Run the test.
            Application.Run(yourTestForm);
        }
    }
    /// <summary>
    /// Contains the startup parameters used to configure 
    /// each new instance of the test form.
    /// </summary>
    public class StartupParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartupPramitures"/> class.
        /// </summary>
        /// <param name="index">The index.</param>
        public StartupParameters(int index)
        {
            this.Index = index;
        }
        /// <summary>
        /// The index for this test form.
        /// </summary>
        public int Index { get; private set; }
    }
