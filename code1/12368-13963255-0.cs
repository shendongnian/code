        void doWithResponse(HttpWebRequest request, Action<HttpWebResponse> responseAction)
        {
            Action wrapperAction = () =>
            {
                request.BeginGetResponse(new AsyncCallback((i_async_result) =>
                {
                    var response = (HttpWebResponse)((HttpWebRequest)i_async_result.AsyncState).EndGetResponse(i_async_result);
                    responseAction(response);
                }), request);
            };
            wrapperAction.BeginInvoke(new AsyncCallback((iar) =>
            {
                var action = (Action)iar.AsyncState;
                action.EndInvoke(iar);
            }), wrapperAction);
        }
