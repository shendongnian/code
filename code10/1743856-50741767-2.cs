    [Route("~/twiml/{p}")]
        [HttpPost]
        public IActionResult GetTwiml(string p)
        {
            //Get the messagedata from the datastore based on the messageId retrieved in request.
            var messageData = GetMessageData(p);
            //initializing Voice Response For creating XML
            var response = new VoiceResponse();
  
            // I have no idea why you have lot of comparison of Voice with string.empty and "0" 
            // so I am not changing it.
            // I am just replacing the Voice, Language and Message variables 
            //with the property values from messageDat object.
            if ((messageData.Voice != string.Empty && messageData.Voice != "0") && (messageData.Voice == "0"))
            {
                //Combining dynamic Message and selecting voice for reading message
                response.Say(messageData.Message, voice: messageData.Voice);
                var XML = new TwiMLResult(response.ToString());
                return XML;
            }
            if ((messageData.Voice != string.Empty && messageData.Voice != "0") && (messageData.Voice != string.Empty && messageData.Voice != "0"))
            {
                //Combining dynamic Message and selecting voice for reading message
                response.Say(messageData.Message, voice: messageData.Voice, language: messageData.Language);
                var XML = new TwiMLResult(response.ToString());
                return XML;
            }
            if ((messageData.Voice == string.Empty || messageData.Voice == "0") && (messageData.Voice == string.Empty || messageData.Voice == "0"))
            {
                //Combining dynamic Message and selecting voice for reading message
                response.Say(messageData.Message);
                var XML = new TwiMLResult(response.ToString());
                return XML;
            }
            return null;
        }
    private MessageData GetMessageData(string messageId)
    {
        MessageData messageData ;
        //retrieve message data based on the messageId and return;
        return messageData;
    }
