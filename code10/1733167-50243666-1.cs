    using (var stream = new FileStream(OUTPUT_FILE, FileMode.Create))
    {
        using (var document = new Document())
        {
            var writer = PdfWriter.GetInstance(document, stream);
            document.Open();
    
            var cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
            // path to fontawesome.css
            cssResolver.AddCssFile(CSS_PATH, true);
    
            // question missing this part - REGISTER the font(s)
            var fontProvider = new XMLWorkerFontProvider(XMLWorkerFontProvider.DONTLOOKFORFONTS);
            // may need to add other web-fonts-with-css\webfonts\*.ttf depending on needs 
            fontProvider.Register(Path.Combine(FONT_PATH, "fa-solid-900.ttf"), "FontAwesome");
            var cssAppliers = new CssAppliersImpl(fontProvider);
    
            var htmlPipelineContext = new HtmlPipelineContext(cssAppliers);
            htmlPipelineContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
    
            var pdfWriterPipeline = new PdfWriterPipeline(document, writer);
            var htmlPipeline = new HtmlPipeline(htmlPipelineContext, pdfWriterPipeline);
            var cssResolverPipeline = new CssResolverPipeline(
                cssResolver, htmlPipeline
            );
    
            var worker = new XMLWorker(cssResolverPipeline, true);
            var parser = new XMLParser(worker);
            using (var stringReader = new StringReader(XHTML))
            {
                parser.Parse(stringReader);
            }
        }
    }
