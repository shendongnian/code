    #region ExportErrorToExcel
        //This function will return the file name to script
        public ActionResult ExportErrorToExcel(string dataExchangeSelectedColum, string entityvalue, string filename)
        {
           
            UA patsUA = Session["PaTSUA"] as UA;
            DataTable dataTable = null;
            dataTable = _dataExchangeBusiness.DataValidation(dataExchangeSelectedColum, entityvalue, filename, patsUA.DBConnectionString);
    
            string tempPath = Server.MapPath("~/Temp/" + Guid.NewGuid().ToString()+ ".xlsx");            
    
            _dataExchangeBusiness.ExportErrorToExcel(dataTable,tempPath, entityvalue);
            string fname = Path.GetFileName(tempPath);
    
            return Json(new { Result = "true", Message = "Success", FileName = fname,Entity=entityvalue });
        }
        #endregion ExportErrorToExcel
