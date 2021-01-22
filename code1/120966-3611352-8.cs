    public object BeforeSendRequest( ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel )
    {
        request.Headers.Add( MessageHeader.CreateHeader( "ImpersonatedUsername", "http://schemas.mycompany.com/MyProject", HttpContext.Current.User.Identity.Name ) );
        return null;
    }
