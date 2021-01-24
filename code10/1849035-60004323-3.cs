    var doc = new HtmlToPdfDocument()
    {
        GlobalSettings = {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Landscape,
            PaperSize = PaperKind.A4,
            DPI = 320,
            Out = path
        },
        Objects = {
            new ObjectSettings() {                               
                PagesCount = true,
                HtmlContent = html,
                WebSettings = { DefaultEncoding = "UTF-8", LoadImages = true },
                FooterSettings = { FontSize = 8, Right = "Page [page] of [toPage]", Line = false, Spacing = 2.812 }
            }
        }
    };
    byte[] bytes = _converter.Convert(doc);
