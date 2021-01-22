    /// <summary>
    /// Main UI form object
    /// </summary>
    public class Form1 : Form
    {
        /// <summary>
        /// Main form load event handler
        /// </summary>
        public Form1()
        {
            // Initialize ONLY. Setup your controls and form parameters here. Custom controls should wait for "FormReady" before starting up too.
            this.Text = "My Program title before form loaded";
            // Size need to see text. lol
            this.Width = 420;
            // Setup the sub or fucntion that will handle your "start up" routine
            this.StartUpEvent += StartUPRoutine;
            // Optional: Custom control simulation startup sequence:
            // Define your class or control in variable. ie. var MyControlClass new CustomControl;
            // Setup your parameters only. ie. CustomControl.size = new size(420, 966); Do not validate during initialization wait until "FormReady" is set to avoid possible null values etc. 
            // Inside your control or class have a property and assign it as bool FormReady - do not validate anything until it is true and you'll be good! 
        }
        /// <summary>
        /// The main entry point for the application which sets security permissions when set.
        /// </summary>
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        #region "WM_Paint event hooking with StartUpEvent"            
        //
        // Create a delegate for our "StartUpEvent"
        public delegate void StartUpHandler();
        //
        // Create our event handle "StartUpEvent"
        public event StartUpHandler StartUpEvent;
        //
        // Our FormReady will only be set once just he way we intendded
        // Since it is a global variable we can poll it else where as well to determine if we should begin code execution !!
        bool FormReady;
        //
        // The WM_Paint message handler: Used mostly to paint nice things to controls and screen
        protected override void OnPaint(PaintEventArgs e)
        {
            // Check if Form is ready for our code ?
            if (FormReady == false) // Place a break point here to see the initialized version of the title on the form window
            {
                // We only want this to occur once for our purpose here.
                FormReady = true;
                //
                // Fire the start up event which then will call our "StartUPRoutine" below.
                StartUpEvent();
            }
            //
            // Always call base methods unless overriding the entire fucntion
            base.OnPaint(e);
        }
        #endregion
        #region "Your StartUp event Entry point"
        //
        // Begin executuing your code here to validate properties etc. and to run your program. Enjoy!
        // Entry point is just following the very first WM_Paint message - an ideal starting place following form load
        void StartUPRoutine()
        {
            // Replace the initialized text with the following
            this.Text = "Your Code has executed after the form's load event";
            //
            // Anyway this is the momment when the form is fully loaded and ready to go - you can also use these methods for your classes to synchronize excecution using easy modifications yet here is a good starting point. 
            // Option: Set FormReady to your controls manulaly ie. CustomControl.FormReady = true; or subscribe to the StartUpEvent event inside your class and use that as your entry point for validating and unleashing its code.
            //
            // Many options: The rest is up to you!
        }
        #endregion
    }
}
