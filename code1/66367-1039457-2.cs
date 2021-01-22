    using Microsoft.Office.Core;
    using PowerPoint = Microsoft.Office.Interop.PowerPoint;
    
    namespace PPInterop
    {
      class Program
      {
		static void Main(string[] args)
		{
			var app = new PowerPoint.Application();
			var pres = app.Presentations;
			var file = pres.Open(@"C:\Presentation1.ppt", MsoTriState.msoTrue, MsoTriState.msoTrue, MsoTriState.msoFalse);
			file.SaveCopyAs(@"C:\presentation1.jpg", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsJPG, MsoTriState.msoTrue);
		}
      }
    }
