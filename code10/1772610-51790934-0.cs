    var output = messages.Where(message => message is TextMessageData || message is ImageDataRecord)
                         .Select(message =>
                         {
                             if (message is TextMessageData)
                             {
                                 return (Message)new TextMessage
                                 {
                                     …
                                 };
                             }
                             else if (message is ImageDataRecord)
                             {
                                 return new ImageMessage
                                 {
                                     …
                                 };
                             }
                             else
                                 throw new Exception();
                         });
