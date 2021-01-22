        using MSDASC;
        using ADODB;
     
        private string BuildConnectionString()
        {
             string strConnString = "";
             object _con = null;
             MSDASC.DataLinks _link = new MSDASC.DataLinks();
             _con = _link.PromptNew();
             if (_con == null) return string.Empty;
             strConnString = ((ADODB.Connection)_con).ConnectionString;
             return strConnString;
        }
 
 
