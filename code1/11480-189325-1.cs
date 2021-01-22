    IAsyncResult BeginPut( string key, object value ) {
        Action<string, object> put = this.Put;
        return put.BeginInvoke( key, value, EndPut,
            new Action<IAsyncResult>( put.EndInvoke ) );
    }
    IAsyncResult BeginPut( string region, string key, object value ) {
        Action<string, string, object> put = this.Put;
        return put.BeginInvoke( region, key, value, EndPut,
            new Action<IAsyncResult>( put.EndInvoke ) );
    }
