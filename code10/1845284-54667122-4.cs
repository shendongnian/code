	Table table = new Table();
	
	lstLabelType.SelectedIndexChanged += (o, e) => SelectDocumentTypeChanged(lstLabelType, table);
	
	
	private void SelectDocumentTypeChanged(DropDownList lstLabelType, Table table)
	{
	    Debug.WriteLine("SelectDocumentTypeChanged() STARTED");
	
	    SPWeb contextWeb = SPContext.Current.Web;
	
	    tipoDocumentoSelezionato = lstLabelType.SelectedValue;
	    this.renderizzaEtichetteFacoltative(tipoDocumentoSelezionato, table);
	
	    string url = contextWeb.Url;
	    string link = url + "/ARXEIA WEBPART/Stampa Etichetta.aspx?IsDlg=1&postazione=" + macchina + "&tipoDoc=" + tipoDocumentoSelezionato;
	    SPUtility.Redirect(link, SPRedirectFlags.Default, Context);
	}
