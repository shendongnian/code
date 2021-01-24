    public FileResult DescargarPDF (int itemId) {
            var presupuesto = ReglasNegocio.Fachada.Consultas.ObtenerPresupuesto(itemId);             
            var archivo = new Rotativa.PartialViewAsPdf("_PresupuestoFinal", presupuesto) { FileName = "Presupuesto_" + itemId + ".pdf", PageSize = Rotativa.Options.Size.A4 };
            var binario = archivo.BuildFile(this.ControllerContext);        
            return File(binario, "application/pdf", archivo.FileName);           
        }
