    FlowDocumentScrollViewer GetFlowDocumentReader(string text)
            {
                FlowDocumentScrollViewer fdr = new FlowDocumentScrollViewer();
    
                FlowDocument fd = new FlowDocument();
                fdr.Document = fd;
                fdr.Margin = new Thickness(0);
                Paragraph par = new Paragraph();
                par.Margin = new Thickness(0);
                fd.Blocks.Add(par);
    
                Run r = new Run(text);
                par.Inlines.Add(r);
    
                fd.PagePadding = new Thickness(0);
                fdr.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                
                return fdr;
            }
