    var file = ctx.Web.GetFileByUrl(fileAbsUrl);
    ctx.Load(file);
    var streamResult = file.OpenBinaryStream();
    ctx.ExecuteQuery();
    //save into file
    using (var fileStream = System.IO.File.Create(@"C:\path\filename.docx"))
    {
       streamResult.Value.Seek(0, SeekOrigin.Begin);
       streamResult.Value.CopyTo(fileStream);
    }
