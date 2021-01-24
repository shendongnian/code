    public class MailController: Controller
    {
       byte[] bytes = System.IO.File.ReadAllBytes(FilePath);
       MailModel model= new MailModel();
       model.file = (HttpPostedFileBase)new MemoryPostedFile(bytes, FilePath, filename);
    }
