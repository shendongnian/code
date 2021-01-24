    // Summary:
    //     Construct the QnA Knowledgebase information.
    //
    // Parameters:
    //   knowledgebaseId:
    //     The QnA Knowledgebase ID.
    //
    //   defaultMessage:
    //     The default message returned when no match found.
    //
    //   scoreThreshold:
    //     The threshold for answer score.
    //
    //   top:
    //     The number of answers to return.
    public QnAMakerAttribute(string authKey, string knowledgebaseId, string defaultMessage = null, double scoreThreshold = 0.3, int top = 1, string endpointHostName = null);
