    void btnApplica_Click_Scelta_Campi_Etichetta(object sender, EventArgs e)
    {
        Debug.Print("btnApplica_Click_Scelta_Campi_Etichetta START");
        ImageButton btnApplica = (ImageButton) sender;
        String idBtn = btnApplica.ID;
    
        SPWeb contextWeb = SPContext.Current.Web;
        string url = contextWeb.Url;
    
        string link = url + "/ARXEIA WEBPART/Carica documento.aspx?mode=scelta_campi_facoltativi_etichetta&obj=" + obj;
    
        SPUtility.Redirect(link, SPRedirectFlags.Default, Context);
    
    }
