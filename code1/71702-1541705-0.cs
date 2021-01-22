    using System.Collections.Generic;
    using Word = Microsoft.Office.Interop.Word;
    
    namespace WordExample
    {
        class WordExample
        {
            #region Constructor
            public WordExample()
            {
                WordApp = new Microsoft.Office.Interop.Word.Application();
            }
            #endregion
    
            #region Fields
            private Word.Application WordApp;
            private object missing = System.Reflection.Missing.Value;
            private object yes = true;
            private object no = false;
            private Word.Document d;
            private object filename = @"C:\FullPathToFile\example.doc";
            #endregion
    
            #region Methods
            public void UpdateDoc()
            {
                d = WordApp.Documents.Open(ref filename, ref missing, ref no, ref missing,
                   ref missing, ref missing, ref  missing, ref  missing, ref  missing,
                   ref  missing, ref missing, ref yes, ref  missing, ref  missing, ref  missing, ref  missing);
                List<Word.Range> ranges = new List<Microsoft.Office.Interop.Word.Range>();
                foreach (Word.InlineShape s in d.InlineShapes)
                {
                    if (s.Type == Microsoft.Office.Interop.Word.WdInlineShapeType.wdInlineShapePicture)
                    {
                        ranges.Add(s.Range);
                        s.Delete();
                    }
                }
                foreach (Word.Range r in ranges)
                {
                    r.InlineShapes.AddPicture(@"c:\PathToNewImage\Image.jpg", ref missing, ref missing, ref missing);
                }
                WordApp.Quit(ref yes, ref missing, ref missing);
            }
            #endregion
 }
}
