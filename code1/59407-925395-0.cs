    public static void CopyStream( Stream input, Stream output )
    {
            var buffer = new byte[32768];
            int readBytes;
            while( ( readBytes = input.Read( buffer, 0, buffer.Length ) ) > 0 )
            {
                    output.Write( buffer, 0, readBytes );
            }
    }
