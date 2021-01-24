     /// <summary>
        /// Here we can handle response.insert response in database
        /// </summary>
        /// <param name="invocationId">The invocation identifier.</param>
        /// <param name="response">The response message instance.</param>
        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
                 logapResponse(response);
            
        }
 
