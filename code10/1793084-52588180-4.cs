    public class ExcelClient : WebClient
    {
        public ExcelClient(string webUrl, ICredentials credentials)
        {
            BaseAddress = webUrl;
            Credentials = credentials;
            Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
        }
        public string ReadTable(string fileUrl, string sheetName, string cellStart,string cellEnd, string format="json")
        {&#xD;
            var endpointUrl = BaseAddress + string.Format("/_vti_bin/ExcelRest.aspx/{0}/Model/Ranges('{1}!{2}|{3}')?$format={4}", fileUrl,sheetName,cellStart,cellEnd,format);
            return DownloadString(endpointUrl);
        }
    }
