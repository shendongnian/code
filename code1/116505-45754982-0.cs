    Call.Do(new Call.CallCommand
    {
     to = new[]
      {
         new Call.Endpoint 
         {
            type = "phone",
            number = NEXMO_TO_NUMBER
         }
      from = new Call.Endpoint
         {
            type = "phone",
            number = NEXMO_FROM_NUMBER
         },
     answer_url = new[]
         {
            NEXMO_CALL_ANSWER_URL
         }
    });
