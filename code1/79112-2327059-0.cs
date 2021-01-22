            HttpListener listener;
        public Form1( ) {
            InitializeComponent( );
            listener = new System.Net.HttpListener( );
            listener.Prefixes.Add( "http://*:88/" );
            listener.Start( );
            IAsyncResult result = listener.BeginGetContext( new AsyncCallback(  ListenerCallback ), listener );
            
        }
        public static void ListenerCallback( IAsyncResult result ) {
        string resp = "<body>test</body";
            HttpListener listener = ( HttpListener )result.AsyncState;
            // Call EndGetContext to complete the asynchronous operation.
            try {
                HttpListenerContext context = listener.EndGetContext( result );
                HttpListenerRequest request = context.Request;
                // Obtain a response object.
                HttpListenerResponse response = context.Response;
                // Construct a response.
                string webpage = request.Url.AbsolutePath.Substring( 1 );
                string responseString = null;
                if ( string.IsNullOrEmpty( webpage ) ) {
                    responseString = resp;
                }
                else {
                    webpage = webpage.Replace( ".", "_" );
                    responseString = webkit_test.Properties.Resources.ResourceManager.GetResourceSet( System.Globalization.CultureInfo.CurrentCulture, true, false ).GetObject( webpage ) as string;
                    if ( responseString == null ) {
                        responseString = "<html></html><body> 404 Web Page not Found</body>";
                    }
                }
                byte[ ] buffer = System.Text.Encoding.UTF8.GetBytes( responseString );
                // Get a response stream and write the response to it.
                response.ContentType = "text/html; charset=UTF-8";
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write( buffer, 0, buffer.Length );
                output.Flush( );
                // You must close the output stream.
                output.Close( );
                IAsyncResult result1 = listener.BeginGetContext( new AsyncCallback( ListenerCallback ), listener );
            }
            catch { }
        }
