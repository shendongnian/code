    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
    public static Boolean realizaConsulta(Dictionary<string, string> datos)
    {
        clsGeneral consulta;
        DataTable dtTemp = new DataTable();
        using (consulta = new clsGeneral("SQLConn"))
        {
            consulta.consultaPrograma(ref dtTemp, datos["Codigo"],  Int16.Parse(datos["Cod_Actividad"]), Int16.Parse(datos["Cod_SubActividad"]), datos["FechaIni"], datos["FechaFin"]);
            HttpContext.Current.Session["Consulta"] = dtTemp;
            
        //THIS ARE THE 3 DIFFERENT WAYS I HAVE TRIED TO CALL THE PRepConsulta.aspx,
        //I DONT KNOW IF THERE IS A BETTHER WAY TO DO IT
        //System.Web.HttpContext.Current.Response.Redirect("PRepConsulta.aspx", false);
        //HttpContext.Current.Server.Transfer("PRepConsulta.aspx", false);
        //System.Web.HttpContext.Current.Server.Execute("PRepConsulta.aspx",writer, false);
        }
        return true;
    }
