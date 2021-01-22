    class Author
       {
           public string Name
           {
               get
               {
                   return "John Borders";
               }
           }
       }
       class Book
       {
           public static string StaticId
           {
               get
               {
                   return "AABB";
               }
           }
           public int BookId
           {
               get
               {
                   return 100;
               }
           }
           public Author Author
           {
               get
               {
                   return new Author();
               }
           }
       }
       public class PropertySample1
       {
           [STAThread]
           static void Main()
           {
               TemplateEngine dt = new TemplateEngine();
               dt.LoadFromFile("Template.tpl");
               Book book = new Book();
               dt.SetValue("bk", book);
               dt.UsingNamespace("CSharp,Demo");
               string output = dt.Run();
               Console.WriteLine(output);
           }
       }
