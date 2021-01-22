    /// <summary>
    /// MessageBox is a class that allows a developer to enqueue messages to be
    /// displayed to the user on the client side, when the page next loads
    /// </summary>
    public class MessageBox : System.Web.UI.UserControl
    {
        /// <summary>
        /// queues up a message to be displayed on the next rendering.
        /// </summary>
        public static void Show( string message )
        {
            Messages.Enqueue( message );
        }
        /// <summary>
        /// queues up a message to be displayed on the next rendering.
        /// </summary>
        public static void Show( string message, params object[] args )
        {
            Show( string.Format( message, args ) );
        }
        
        /// <summary>
        /// override of OnPreRender to render any items in the queue as javascript
        /// </summary>
        protected override void OnPreRender( EventArgs e )
        {
            base.OnPreRender( e );
            if ( Messages.Count > 0 )
            {
                StringBuilder script = new StringBuilder();
                int count = 0;
                script.AppendLine( "var messages = new Array();" );
                while ( Messages.Count > 0 )
                {
                    string text = Messages.Dequeue();
                    text = text.Replace( "\\", "\\\\" );
                    text = text.Replace( "\'", "\\\'" );
                    text = text.Replace( "\r", "\\r" );
                    text = text.Replace( "\n", "\\n" );
                    script.AppendFormat( "messages[{0}] = '{1}';{2}", count++, HttpUtility.HtmlEncode(text), Environment.NewLine );
                }
                if ( string.IsNullOrEmpty( Callback ) )
                {
                    // display as "alert"s if callback is not specified
                    script.AppendFormat( "for(i=0;i<messages.length;i++) alert(messages[i]);{0}", Environment.NewLine );
                }
                else
                {
                    // call the callback if specified
                    script.AppendFormat( "{0}(messages);{1}", Callback, Environment.NewLine );
                }
                Page.ClientScript.RegisterStartupScript( this.GetType(), "messages", script.ToString(), true );
            }
        }
        /// <summary>
        /// gets or sets the name of the javascript method to call to display the messages
        /// </summary>
        public string Callback
        {
            get { return callback; }
            set { callback = value; }
        }
        private string callback;
        /// <summary>
        /// helper to expose the queue in the session
        /// </summary>
        private static Queue<string> Messages
        {
            get
            {
                Queue<string> messages = (Queue<string>)HttpContext.Current.Session[MessageQueue];
                if ( messages == null )
                {
                    messages = new Queue<string>();
                    HttpContext.Current.Session[MessageQueue] = messages;
                }
                return messages;
            }
        }
        private static string MessageQueue = "MessageQueue";
    }
