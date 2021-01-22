    static void Main(string[] args)
    {
        Random rnd = new Random();
        XDocument galleries = XDocument.Load(@"C:\Users\John Boker\Documents\Visual Studio 2008\Projects\ConsoleApplication1\ConsoleApplication1\Galleries.xml");
        var image = (from g in galleries.Descendants("Gallery")
                     where g.Attribute("ID").Value == "10C31804CEDB42693AADD760C854ABD"
                     select g.Descendants("Images").Descendants("Image").OrderBy(r=>rnd.Next()).First()).First();
        Console.WriteLine(image);
        Console.ReadLine();
    }
