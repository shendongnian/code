    using DocuSign.eSign.Api;
    using DocuSign.eSign.Client;
    using DocuSign.eSign.Model;
    
    public void ResendEnvelope(Guid envelopeId, string senderEmail)
    {
        Configuration apiConfiguration = GetApiConfiguration(sendOnBehalfOfEmail: senderEmail); //Private method that gets our api configuration: works fine in other calls
        EnvelopesApi envApi = new EnvelopesApi(apiConfiguration);
        Envelope resendEnvelope = new Envelope()
        {
            EnvelopeId = envelopeId.ToString()
        };
    
        EnvelopeUpdateSummary apiResponse = envApi.Update(AccountId, envelopeId.ToString(), resendEnvelope, new EnvelopesApi.UpdateOptions() { resendEnvelope = "true" }); //AccountId is set on class initialization: works fine in other calls
        if (!string.IsNullOrEmpty(apiResponse.ErrorDetails?.ErrorCode))
        {
            throw new ApplicationException($"Resending Envelope in DocuSign returned the following error: Code: {apiResponse.ErrorDetails?.ErrorCode }; Message: {apiResponse.ErrorDetails?.Message}");
        }
    }
