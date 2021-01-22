	private void OnValidateCertificateError(object sender, CertificateValidationEventArgs e)
	{
		string msg = string.Format(Strings.OnValidateCertificateError, e.Request.RequestUri, e.Certificate.GetName(), e.Problem, new Win32Exception(e.Problem).Message);
		LogWriter.LogError(msg);
		//Message.ShowError(msg);
	}
