        public static class MyExtensions
        {
            public static string ParentAndSelf(this XElement self, XElement parent)
            {
                self.Elements().Remove();
                if (parent != null && parent.Name.Equals(self.Name))
                {
                    parent.Elements().Remove();
                    parent.Add(self);
                    return parent.ToString();
                }
                else
                    return self.ToString();
            }
        }
    
        class Program
        {
            [STAThread]
            static void Main()
            {
                string xml = 
                @"<categories>
                    <category text=""Arts"">            
                        <category text=""Design""/>            
                        <category text=""Visual Arts""/>    
                    </category>    
                    <category text=""Business"">            
                        <category text=""Business News""/>            
                        <category text=""Careers""/>            
                        <category text=""Investing""/>    
                    </category>    
                    <category text=""Comedy""/>
                </categories>";
    
                XElement doc = XElement.Parse(xml);
    
                PrintMatch(doc, "Business News");
                PrintMatch(doc, "Business");
            }
    
            static void PrintMatch(XElement doc, string searchTerm)
            {
                var hit = (from category in doc
                       .DescendantsAndSelf("category")
                           where category.Attributes("text")
                           .FirstOrDefault()
                           .Value.Equals(searchTerm)
                           let parent = category.Parent
                           select category.ParentAndSelf(parent)).SingleOrDefault();
    
                Console.WriteLine(hit);
                Console.WriteLine();
            }
        }
  
