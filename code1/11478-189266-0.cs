    IAsyncResult BeginPut(string key, object value) {
       return this.BeginPut(null, key, value);
    }
    IAsyncResult BeginPut(string region, string key, object value) {
       Action<string, string, object> put = this.Put;
       return put.BeginInvoke(region, key, value, null, null);
    }
    void EndPut(IAsyncResult asyncResult) {
       var put = (Action<string, string, object>)((AsyncResult)asyncResult).AsyncDelegate;
       put.EndInvoke(asyncResult);
    }
