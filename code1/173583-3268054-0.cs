      public static void Main(string[] args)
        {
            string aspxCode = @"<html><head><title>Test Page</title></head>
                                <body id=""bodyID"">        
            <asp:Label runat=""server"" id=""lbl1"" text=""First Name:"" />
            <asp:TextBox runat=""server"" id=""txt1"" /><br />
            <asp:Label runat=""server"" id=""lbl2"" text=""Last Name:"" />
            <asp:TextBox runat=""server"" id=""txt2""></asp:TextBox>
        </body>
    </html>";
            XElement xDoc = XElement.Parse(aspxCode.Replace("asp:", "asp-"));
            var allMatchingASPtags = xDoc.Descendants()
                   .Where(d => d.Name.LocalName.StartsWith("asp-"))
                   .Select(c => c.Attribute("id").Value);
            foreach (var t in allMatchingASPtags)
            {
                Console.WriteLine(t);
            }
            Console.ReadLine();
