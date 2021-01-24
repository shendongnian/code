        public static string RenderHTMLFile(Document doc)
        {
            string fn = Path.GetTempPath() + TmpPrefix +GUID() + ".html";
            var vba = doc.VBProject;
            var module = vba.VBComponents.Add(Microsoft.Vbe.Interop.vbext_ComponentType.vbext_ct_StdModule);
            var code = Properties.Resources.HTMLRenderer;
            module.CodeModule.AddFromString(code);
            var dataMacro = Word.Run("renderHTMLCopy", fn); 
            return fn;
        }
