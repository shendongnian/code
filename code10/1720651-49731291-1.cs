    public class MailController: Controller
    {
       MailModel mm = new MailModel();
       byte[] bytes = System.IO.File.ReadAllBytes(FilePath);
       mm.file = (HttpPostedFileBase)new MemoryPostedFile(bytes, FilePath, filename);
    }
