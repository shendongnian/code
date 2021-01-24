        public static List<string> ZplFromPdf(string pdfBase64, int dpi = 300)
        {
            return ZplFromPdf(new MemoryStream(Convert.FromBase64String(pdfBase64)), new Size(0,0), dpi);
        }
        public static List<string> ZplFromPdf(Stream pdf, Size size, int dpi = 300)
        {
            var zpls = new List<string>();
            if (size == new Size(0, 0))
            {
                size = new Size(812, 1218);
            }
            using (var rasterizer = new GhostscriptRasterizer())
            {
                rasterizer.Open(pdf);
                var images = new List<Image>();
                for (int pageNumber = 1; pageNumber <= rasterizer.PageCount; pageNumber++)
                {
                    var bmp = new Bitmap(rasterizer.GetPage(dpi, dpi, pageNumber), size.Width, size.Height);
                    var zpl = new StringBuilder();
                    zpl.Append(ZPLHelper.GetGrfStoreCommand("R:LBLRA2.GRF", bmp));
                    zpl.Append("^XA^FO0,0^XGR:LBLRA2.GRF,1,1^FS^XZ");
                    zpl.Append("^XA^IDR:LBLRA2.GRF^FS^XZ");
                    zpls.Add(zpl.ToString());
                }
                return zpls;
            }
        }
