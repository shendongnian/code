    byte[] buffer[1000];
    int size;
    unsafe
    {
      fixed ( byte* p = buffer )
      {
        size = GetError( ???, p, buffer.Length ); 
      }
    }
    string result = System.Text.Encoding.Default.GetString( buffer, 0, size );
