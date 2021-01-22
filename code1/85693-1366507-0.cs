    byte[] buffer = new byte[2048];
    int bytesReceived = 0;
    // ... somewhere later, getting data from client ...
    bytesReceived = deviceSocket.Receive( buffer );
    Debug.WriteLine( String.Format( "{0} bytes received", bytesReceived ) );
    // now process the 'bytesReceived' bytes in the buffer
    for( int i = 0; i < bytesReceived; i++ )
    {
        Debug.WriteLine( buffer[i] );
    }
