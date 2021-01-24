    try
    {
        var type = Type.GetTypeFromProgID("Word.Application");
        dynamic app = Activator.CreateInstance(type);
        app.Visible = true;
   
        dynamic doc = app.Documents.Add();
        doc.Content.InsertAfter("Hello world!");
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
    }
