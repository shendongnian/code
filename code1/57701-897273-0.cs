    using System;
    using System.IO;
    public class HtmlTemplate
    {
        private string _html;
        public HtmlTemplate(string templatePath)
        {
            using (var reader = new StreamReader(templatePath))
                _html = reader.ReadToEnd();
        }
        public string Render(object values)
        {
            string output = _html;
            foreach (var p in values.GetType().GetProperties())
                output = output.Replace("[" + p.Name + "]", (p.GetValue(values, null) as string) ?? string.Empty);
            return output;
        }
    }
    public class Program
    {
        void Main()
        {
            var template = new HtmlTemplate(@"C:\MyTemplate.txt");
            var output = template.Render(new {
                TITLE = "My Web Page",
                METAKEYWORDS = "Keyword1, Keyword2, Keyword3",
                BODY = "Body content goes here",
                ETC = "etc"
            });
            Console.WriteLine(output);
        }
    }
