    public class FileTypes
    {
     public static readonly Pdf = new FileTypes("pdf", "Adobe Acrobat");
     public static readonly Excel = new FileTypes("xls", "Microsoft Excel");
     
     private FileTypes(string extension, string programName)
     {
      Extenssion = extension;
      ProgramName = programName;
     }
     
     public string Extension { get; private set; }
     public string ProgramName { get; private set; }
    }
    
    this can then be used like this:
    
    FileTypes.Excel.Extension
    FileTypes.Excel.ProgramName
