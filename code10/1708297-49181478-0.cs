    private void OnMessage(object resp, Dictionary<string, object> customData)
         {
             fsData fsdata = null;
             fsResult r = _serializer.TrySerialize(resp.GetType(), resp, out fsdata);
             if (!r.Succeeded)
                 throw new WatsonException(r.FormattedMessages);
     
             //  Convert fsdata to MessageResponse
             MessageResponse messageResponse = new MessageResponse();
             object obj = messageResponse;
             r = _serializer.TryDeserialize(fsdata, obj.GetType(), ref obj);
             if (!r.Succeeded)
                 throw new WatsonException(r.FormattedMessages);
     
             //  Set context for next round of messaging
             object _tempContext = null;
             (resp as Dictionary<string, object>).TryGetValue("context", out _tempContext);
     
             if (_tempContext != null)
                 _context = _tempContext as Dictionary<string, object>;
             else
                 Log.Debug("ExampleConversation.OnMessage()", "Failed to get context");
             //_waitingForResponse = false;
     
             //if we get a response, do something with it (find the intents, output text, etc.)
             if (resp != null && (messageResponse.intents.Length > 0 || messageResponse.entities.Length > 0))
             {
                 string intent = messageResponse.intents[0].intent;
                 //foreach (string WatsonResponse in messageResponse.output.text) {
                 //    outputText += WatsonResponse + " ";
                 //}
     
    
                 outputText = messageResponse.output.text[0];
                 Debug.Log("Intent/Output Text: " + intent + "/" + outputText);
                 if (intent.Contains("exit")) {
                     stopListeningFlag = true;
                 }
                 CallTTS (outputText);
                 outputText = "";
             }
         }
