cs
private void Button_Click(object sender, RoutedEventArgs e)
        {
            FlowDocument fd = new FlowDocument();
            
//TaskViewModel.Tasks is the collection (List<> in my case) your ListView takes data from
            foreach (var item in TaskViewModel.Tasks)            {
                fd.Blocks.Add(new Paragraph(new Run(item.ToString()))); //you may need to create a ToString method in your type, if it's string it's ok
            }
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() != true) return;
            fd.PageHeight = pd.PrintableAreaHeight;
            fd.PageWidth = pd.PrintableAreaWidth;
            IDocumentPaginatorSource idocument = fd as IDocumentPaginatorSource;
            pd.PrintDocument(idocument.DocumentPaginator, "Printing Flow Document...");
        }
