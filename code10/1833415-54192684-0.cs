    #region DataValidation
    
        public ActionResult DataValidation(string dataExchangeSelectedColum, string entityvalue,string filename)
        {
            UA patsUA = Session["PaTSUA"] as UA;
            DataTable dataTable = null;
             dataTable = _dataExchangeBusiness.DataValidation(dataExchangeSelectedColum, entityvalue, filename, patsUA.DBConnectionString);
          
    
            return PartialView("_ExcelDataTable", dataTable);
        }
        #endregion DataValidation
