    if (_EditAO.UniversityOffer == null)
    {
    	_NAAService.EditNAA_ApplicationOffer(ApplicationId, UniversityOffer);
    }
    else
    {
    	throw new SoapException("Some error has occurred", SoapException.ClientFaultCode);
    }
