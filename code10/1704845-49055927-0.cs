    private void RegistrarAutorizacion()
    {
        try
        {
            foreach (GridViewRow grd_Row in this.gvwAutorizaciones.Rows)
            {
                string Comprobante = Convert.ToString(grd_Row.Cells[0].Text.Replace("&nbsp;", ""));
                string SerieComprobante = Convert.ToString(grd_Row.Cells[1].Text.Replace("&nbsp;", ""));
                string RucEmisor = Convert.ToString(grd_Row.Cells[2].Text.Replace("&nbsp;", ""));
                string RazSocEmisor = Convert.ToString(grd_Row.Cells[3].Text.Replace("&nbsp;", ""));
                //DateTime FechaEmision = Convert.ToDateTime(grd_Row.Cells[4].Text.Replace("&nbsp;", ""));
                //DateTime FechaAutorizacion = Convert.ToDateTime(grd_Row.Cells[5].Text.Replace("&nbsp;", ""));
                var FechaEmision = DateTime.ParseExact(
                    grd_Row.Cells[4].Text.Replace("&nbsp;", ""), 
                    "dd/M/yyyy", CultureInfo.InvariantCulture); 
                var FechaAutorizacion = DateTime.ParseExact(
                    grd_Row.Cells[5].Text.Remove(10,9),
                    "dd/M/yyyy", CultureInfo.InvariantCulture); //file text has time, but for my process is not important the hour
                string TipoEmision = Convert.ToString(grd_Row.Cells[6].Text.Replace("&nbsp;", ""));
                string IdentidadRecepetor = Convert.ToString(grd_Row.Cells[7].Text.Replace("&nbsp;", ""));
                string ClaveAcceso = Convert.ToString(grd_Row.Cells[9].Text.Replace("&nbsp;", ""));
                string NumeroAutorizacion = Convert.ToString(grd_Row.Cells[10].Text.Replace("&nbsp;", ""));
                autorizDL.RegistrarAutorizacion(
                    Comprobante, SerieComprobante, RucEmisor, RazSocEmisor,
                    Convert.ToDateTime(FechaEmision),
                    Convert.ToDateTime(FechaAutorizacion),
                    TipoEmision, IdentidadRecepetor, ClaveAcceso, NumeroAutorizacion);
            }
        }
        catch (System.FormatException sfex) { }
        //catch (Exception ex) { }
        
    }
