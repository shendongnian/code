        public static void RenderTemplate(String templatepath, System.IO.Stream outstream, XElement xml, Dictionary<String, object> otherdata)
        {
            var templateFile = System.IO.File.ReadAllText(templatepath);
            var interpreter = new Interpreter();
            interpreter.ReferencedAssemblies.Add("System.Core.dll"); // linq extentions
            interpreter.ReferencedAssemblies.Add("System.Xml.dll");
            interpreter.ReferencedAssemblies.Add("System.Xml.Linq.dll");
            interpreter.UsingReferences.Add("System.Linq");
            interpreter.UsingReferences.Add("System.Xml");
            interpreter.UsingReferences.Add("System.Xml.Linq");
            interpreter.UsingReferences.Add("System.Collections.Generic");
            interpreter.Execute(templateFile, outstream, xml, otherdata);
        }
