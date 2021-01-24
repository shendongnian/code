    DTE dte = Package.GetGlobalService(typeof(DTE)) as DTE;
            TextDocument activeDoc = dte.ActiveDocument.Object() as TextDocument;
            var text = activeDoc.CreateEditPoint(activeDoc.StartPoint).GetText(activeDoc.EndPoint);
            
            var input = (text);
            Regex regex = new Regex(@"(meta:resourcekey)+(\W)+(\w*)+(\W)");
            var match = regex.Matches(input);
            string matches = string.Empty;
            foreach(var item in match)
            {
                matches += item.ToString() + " "; 
            }
            MessageBox.Show(matches);
 
