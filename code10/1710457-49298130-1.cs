     public Task OnCertificateValidation(object sender,CertificateValidationEventArgs e)
    {           
        //set IsValid to true/false based on Certificate Errors
        e.IsValid = true;         
        return Tasks.FromResult(0);
    }
