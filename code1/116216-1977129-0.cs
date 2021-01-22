    using (var stream = dlg.OpenFile())
    using (var writer = new System.IO.StreamWriter(stream))
    {
        writer.WriteLine("Success");
    }
