        private object missing = System.Reflection.Missing.Value;
        .....other code.....
            foreach (Microsoft.Office.Interop.Word.Shape s in wordApp.ActiveDocument.Shapes)
            {
                if (s.AlternativeText.ToUpper().Contains("FOTO"))
                {
                    object A = s.Anchor;
                    Shape new = Brief.Shapes.AddPicture(@"mynewpicture.jpg", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,ref A);
                    new.Top = s.Top;
                    new.Left = s.Left;
                    new.Width = s.Width;
                    new.Height = s.Height;
                    s.Delete();
                }
            }
