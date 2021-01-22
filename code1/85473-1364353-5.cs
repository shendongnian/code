    public partial class SplashForm : Form
    {
        #region Public Methods
        /// <summary>
        /// Shows the splash screen with no fading effects.
        /// </summary>
        public new static void Show()
        {
            Show( 0 );
        }
        /// <summary>
        /// Shows the splash screen.
        /// </summary>
        /// <param name="fadeTimeInMilliseconds">The time to fade
        /// in the splash screen in milliseconds.</param>
        public static void Show( int fadeTimeInMilliseconds )
        {
            // Only show the splash screen once.
            if ( _instance == null ) {
                _fadeTime = fadeTimeInMilliseconds;
                _instance = new SplashForm();
                // Hide the form initially to avoid any pre-paint flicker.
                _instance.Opacity = 0;
                ( ( Form ) _instance ).Show();
                // Process the initial paint events.
                Application.DoEvents();
                if ( _fadeTime > 0 ) {
                    // Calculate the time interval that will be used to
                    // provide a smooth fading effect.
                    int fadeStep = ( int ) Math.Round( ( double ) _fadeTime / 20 );
                    _instance.fadeTimer.Interval = fadeStep;
                    // Perform the fade in.
                    for ( int ii = 0; ii <= _fadeTime; ii += fadeStep ) {
                        Thread.Sleep( fadeStep );
                        _instance.Opacity += 0.05;
                    }
                } else {
                    // Use the Tag property as a flag to indicate that the
                    // form is to be closed immediately when the user calls
                    // Hide();
                    _instance.fadeTimer.Tag = new object();
                }
                _instance.Opacity = 1;
            }
        }
        /// <summary>
        /// Closes the splash screen.
        /// </summary>
        public new static void Hide()
        {
            if ( _instance != null ) {
                // Invoke the Close() method on the form's thread.
                _instance.BeginInvoke( new MethodInvoker( _instance.Close ) );
                // Process the Close message on the form's thread.
                Application.DoEvents();
            }
        }
        #endregion Public Methods
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the SplashForm class.
        /// </summary>
        public SplashForm()
        {
            InitializeComponent();
            Size = BackgroundImage.Size;
            // If transparency is ever needed, set the color of the desired
            // transparent portions of the bitmap to fuschia and then
            // uncomment this code.
            //Bitmap bitmap = new Bitmap(this.BackgroundImage);
            //bitmap.MakeTransparent( System.Drawing.Color.Fuchsia );
            //this.BackgroundImage = bitmap;
        }
        #endregion Constructors
        #region Protected Methods
        protected override void OnClosing( CancelEventArgs e )
        {
            base.OnClosing( e );
            // Check to see if the form should be closed immediately.
            if ( fadeTimer.Tag != null ) {
                e.Cancel = false;
                _instance = null;
                return;
            }
            // Only use the timer to fade if the form is running.
            // Otherwise, there will be no message pump.
            if ( Application.OpenForms.Count > 1 ) {
                if ( Opacity > 0 ) {
                    e.Cancel = true; // prevent the form from closing
                    Opacity -= 0.05;
                    // Use the timer to iteratively call the Close method.
                    fadeTimer.Start();
                } else {
                    fadeTimer.Stop();
                    e.Cancel = false;
                    _instance = null;
                }
            } else {
                if ( Opacity > 0 ) {
                    Thread.Sleep( fadeTimer.Interval );
                    Opacity -= 0.05;
                    Close();
                } else {
                    e.Cancel = false;
                    _instance = null;
                }
            }
        }
        #endregion Protected Methods
        #region Private Methods
        private void OnTick( object sender, EventArgs e )
        {
            Close();
        }
        #endregion Private Methods
        #region Private Fields
        private static SplashForm _instance = null;
        private static int _fadeTime = 0;
        #endregion Private Fields
    }
