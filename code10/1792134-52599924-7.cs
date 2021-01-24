    /// <summary>
    /// Generate PDF invoice file.
    /// It wuill create X PDF temp files "with consecutive file names" for - at the end
    /// of the process - merge those PDF temp files in a single one PDF file.
    /// Temp PDF files will be deleted after creating the PDF merged file.
    /// </summary>
    /// <param name="formFactura">DataTable with the values of the PDF template.</param>
    /// <param name="DetalleFactura">DataTable with the JSON - DataTable (known as details or detalles).</param>
    /// <param name="ruta_archivo_salida">File name and path of the PDF unified file.</param>
    /// <returns>string</returns>
    private string GenerateInvoice(DataTable formFactura, DataTable DetalleFactura, string ruta_archivo_salida)
    {
        // Inicializar variables.
        string msg = "";
        List<string> rutas_archivos = new List<string>();
    
        try
        {
            if (File.Exists(plantilla_factura_manual))
            {
                try
                {
                    // Crear X cantidad de archivos.
                    // "PAGE_SEPARATOR" es el nombre de la columna que posee los valores separados por bloques.
                    DataView view = new DataView(DetalleFactura);
                    DataTable distinctValues = view.ToTable(true, "PAGE_SEPARATOR");
                    double cantPaginas = distinctValues.Rows.Count;
                    for (int pagina = 0; pagina < cantPaginas; pagina++)
                    {
                        using (PdfReader pdfReader = new PdfReader(plantilla_factura_manual))
                        {
                            // Agregar la ruta del archivo temporal PDF a generar.
                            rutas_archivos.Add(ruta_factura_generada.Replace(".pdf", "(" + pagina + ").pdf"));
    
                            PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(ruta_factura_generada.Replace(".pdf", "(" + pagina + ").pdf"), FileMode.OpenOrCreate));
                            AcroFields pdfFormFields = pdfStamper.AcroFields;
    
                            // Llenar las variables de la plantilla en el archivo PDF en construcción.
                            for (int i = 0; i < formFactura.Rows.Count; i++)
                            {
                                pdfFormFields.SetField(formFactura.Rows[i][0].ToString(), formFactura.Rows[i][1].ToString(), true);// set form pdfFormFields
                            }
    
                            #region Diseño grid factura
    
                            PdfPCell cell = null;
                            PdfPTable table = null;
    
                            table = new PdfPTable(9);
                            table.HorizontalAlignment = Element.ALIGN_LEFT;
                            table.SetWidths(new float[] { 22f, 22f, 22f, 22f, 22f, 22f, 22f, 22f, 22f });
                            //table.SpacingBefore = 5;
                            table.TotalWidth = 800f;
    
                            DataRow[] filas_a_usar = DetalleFactura.Select("PAGE_SEPARATOR = " + pagina);
                            foreach (DataRow r in filas_a_usar)
                            {
                                DataRow row = r;
                                object valorFacturaPDFColumna0 = row.Field<string>("PROVIDER") == null ? string.Empty : row.Field<string>("PROVIDER").ToString();
                                object valorFacturaPDFColumna1 = row.Field<string>("DESCRIPTION") == null ? string.Empty : row.Field<string>("DESCRIPTION").ToString();
                                object valorFacturaPDFColumna2 = row.Field<string>("PPTO") == null ? string.Empty : row.Field<string>("PPTO").ToString();
                                object valorFacturaPDFColumna3 = row.Field<string>("JOB_MEDIA_TYPE") == null ? string.Empty : row.Field<string>("JOB_MEDIA_TYPE").ToString();
                                object valorFacturaPDFColumna4 = row.Field<string>("VEND_INV_NO") == null ? string.Empty : row.Field<string>("VEND_INV_NO").ToString();
                                //object valorFacturaPDFColumna5 = row.Field<string>("ORDER_MEDIA") == null ? string.Empty : row.Field<string>("ORDER_MEDIA").ToString();
                                //object valorFacturaPDFColumna6 = row.Field<string>("ACTIVITY_MONTH") == null ? string.Empty : row.Field<string>("ACTIVITY_MONTH").ToString();
                                object valorFacturaPDFColumna7 = row.Field<string>("COMMISSIONABLE") == null ? string.Empty : row.Field<string>("COMMISSIONABLE").ToString();
                                object valorFacturaPDFColumna8 = row.Field<string>("NON_COMMISSIONABLE") == null ? string.Empty : row.Field<string>("NON_COMMISSIONABLE").ToString();
                                string valorFacturaPDFColumna9 = row.Field<string>("IVA_PROVEEDOR") == null ? string.Empty : row.Field<string>("IVA_PROVEEDOR").ToString();
                                string valorFacturaPDFColumna10 = row.Field<string>("TOTAL") == null ? string.Empty : row.Field<string>("TOTAL").ToString();
    
                                //Columnas table
                                cell = PhraseCell(new Phrase(valorFacturaPDFColumna0.ToString(), GettypeStyle()));
                                table.AddCell(cell);
    
                                cell = PhraseCell(new Phrase(valorFacturaPDFColumna1.ToString(), GettypeStyle()));
                                table.AddCell(cell);
    
                                cell = PhraseCell(new Phrase(valorFacturaPDFColumna2.ToString(), GettypeStyle()));
                                table.AddCell(cell);
    
                                cell = PhraseCell(new Phrase(valorFacturaPDFColumna3.ToString(), GettypeStyle()));
                                table.AddCell(cell);
    
                                cell = PhraseCell(new Phrase(valorFacturaPDFColumna4.ToString(), GettypeStyle()));
                                table.AddCell(cell);
    
                                //cell = PhraseCell(new Phrase(valorFacturaPDFColumna5.ToString(), GettypeStyle()));
                                //table.AddCell(cell);
    
                                //cell = PhraseCell(new Phrase(valorFacturaPDFColumna6.ToString(), GettypeStyle()));
                                //table.AddCell(cell);
    
                                cell = PhraseCell(new Phrase(valorFacturaPDFColumna7.ToString(), GettypeStyle()));
                                table.AddCell(cell);
    
                                cell = PhraseCell(new Phrase(valorFacturaPDFColumna8.ToString(), GettypeStyle()));
                                table.AddCell(cell);
    
                                cell = PhraseCell(new Phrase(valorFacturaPDFColumna9.ToString(), GettypeStyle()));
                                table.AddCell(cell);
    
                                cell = PhraseCell(new Phrase(valorFacturaPDFColumna10.ToString(), GettypeStyle()));
                                table.AddCell(cell);
                            }
    
                            ColumnText ct = new ColumnText(pdfStamper.GetOverContent(1));
                            ct.AddElement(table);
                            //iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(18, 370, 800, 36);
                            iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(16, 320, 900, 16);
                            rect.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                            rect.BorderWidth = 15;
                            rect.BorderColor = new BaseColor(0, 0, 0);
                            rect.Border = iTextSharp.text.Rectangle.BOX;
                            ct.SetSimpleColumn(rect);
                            ct.Go();
    
                            #endregion
    
                            // flatten the form to remove editting options, set it to false
                            // to leave the form open to subsequent manual edits
                            pdfStamper.FormFlattening = true;
                            pdfStamper.FreeTextFlattening = true;
                            pdfStamper.Writer.CloseStream = true;
                            pdfStamper.Close();// close the pdf
                        }
                    }
    
                    // Unir los archivos PDF's en uno solo.
                    MergePDFs(rutas_archivos, ruta_archivo_salida);
    
                    #region Eliminar archivos PDF temporales.
    
                    try
                    {
                        foreach (string archivo in rutas_archivos)
                        {
                            File.Delete(archivo);
                        }
                    }
                    catch (Exception ex)
                    {
                        RegistrarEventosDelPrograma("Error al eliminar archivos PDF temporales: " + ex.ToString(), "Error al eliminar archivos PDF temporales");
                    }
    
                    #endregion
                }
                catch (Exception ex)
                {
                    msg += "- Hay un error con la plantilla. Consulte el log de eventos." + SALTO_DE_LINEA;
                    RegistrarEventosDelPrograma("Error al usar la plantilla (" + Path.GetFileName(plantilla_factura_manual) + "): " + ex.ToString(), "Error al usar la plantilla (" + Path.GetFileName(plantilla_factura_manual) + ")");
                }
            }
        }
        catch (Exception ex)
        {
            msg += "- Hubo un error inesperado al generar el archivo PDF. Consulte el log de eventos.";
            RegistrarEventosDelPrograma("Error al generar el archivo PDF. Detalles: " + ex.ToString(), "Error al generar PDF - Plantilla");
        }
    
        return msg;
    }
