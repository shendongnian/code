    Document doc = new Document(MyDir + @"input.doc");
    
    Node[] runs = doc.GetChildNodes(NodeType.Run, true).ToArray();
    for (int i = 0; i < runs.Length; i++)
    {
        Run run = (Run)runs[i];
        int length = run.Text.Length;
    
        Run currentNode = run;
        for (int x = 1; x < length; x++)
        {
            currentNode = SplitRun(currentNode, 1);
        }
    }
    
    DocumentBuilder builder = new DocumentBuilder(doc);
    PageSetup ps = builder.PageSetup;
    
    NodeCollection smallRuns = doc.GetChildNodes(NodeType.Run, true);
    LayoutCollector collector = new LayoutCollector(doc);
    
    int pageIndex = 1;
    foreach (Run run in smallRuns)
    {
        if (collector.GetStartPageIndex(run) == pageIndex)
        {
            Shape watermark = new Shape(doc, Aspose.Words.Drawing.ShapeType.TextPlainText);
            watermark.RelativeHorizontalPosition = RelativeHorizontalPosition.Page;
            watermark.RelativeVerticalPosition = RelativeVerticalPosition.Page;
    
            watermark.Width = 300;
            watermark.Height = 70;
            watermark.HorizontalAlignment = HorizontalAlignment.Center;
            watermark.VerticalAlignment = VerticalAlignment.Center;
    
            watermark.Rotation = -40;
            watermark.Fill.Color = Color.Gray;
            watermark.StrokeColor = Color.Gray;
    
            watermark.TextPath.Text = "watermarkText";
            watermark.TextPath.FontFamily = "Arial";
    
            watermark.Name = string.Format("WaterMark_{0}", Guid.NewGuid());
            watermark.WrapType = WrapType.None;
    
            builder.MoveTo(run);
            builder.InsertNode(watermark);
    
            pageIndex++;
        }
    }
    
    doc.Save(MyDir + @"output\18.3.doc");
    ///////////////////////////////////////
    private static Run SplitRun(Run run, int position)
    {
        Run afterRun = (Run)run.Clone(true);
        afterRun.Text = run.Text.Substring(position);
        run.Text = run.Text.Substring((0), (0) + (position));
        run.ParentNode.InsertAfter(afterRun, run);
        return afterRun;
    }
