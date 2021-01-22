    void DoWithResponse(HttpWebRequest request, Action<HttpWebResponse> responseAction)
    {
        Action wrapperAction = () =>
        {
            request.BeginGetResponse(new AsyncCallback((iar) =>
            {
                var response = (HttpWebResponse)((HttpWebRequest)iar.AsyncState).EndGetResponse(iar);
                responseAction(response);
            }), request);
        };
        wrapperAction.BeginInvoke(new AsyncCallback((iar) =>
        {
            var action = (Action)iar.AsyncState;
            action.EndInvoke(iar);
        }), wrapperAction);
    }
