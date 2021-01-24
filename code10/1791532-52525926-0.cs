    private byte[] ObtenerMitadPdf(byte[] Contenido)
        {
            using (var pdfReader = new PdfReader(Contenido))
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var stamper = new PdfStamper(pdfReader, memoryStream))
                    {
                        for (int i = 1; i <= pdfReader.NumberOfPages; i++)
                        {
                            var pagina = pdfReader.GetPageN(i);
                            var tamañoPagina = pdfReader.GetPageSizeWithRotation(i);
                            var mediaBox = new PdfRectangle(tamañoPagina.Left, tamañoPagina.Bottom,
                                tamañoPagina.Left + (tamañoPagina.Width / 2), tamañoPagina.Top, tamañoPagina.Rotation);
                            pagina.Put(PdfName.MEDIABOX, mediaBox);
                            stamper.MarkUsed(pagina);
                        }
                    }
                    return memoryStream.ToArray();                   
                }
            }
        }
