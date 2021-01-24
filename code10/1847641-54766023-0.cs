    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public static string TraerInstructivos()
    {
        try
        {
            List<InstructivoDTO> response = Controles_Instructivo_Instructivos.TraerInstructivos();
            var json = new JavaScriptSerializer().Serialize(response);
            return json;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }
