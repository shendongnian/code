            XDocument projects = XDocument.Load(fileName);
            XNamespace xmlns = "http://schemas.microsoft.com/developer/msbuild/2003";
            // Delete element (<Compile Include="SerializedData\Tables.xml" />);
            var query1 = from p in projects.Descendants(xmlns + "Project").Descendants(xmlns + "ItemGroup").Descendants(xmlns + "Compile") 
                         where p.Attribute("Include").Value == @"SerializedData\Tables.xml" select p;
            if (query1.Any())
            {
                XElement node = query1.Single();
                node.Remove(); 
            }
            //System.Diagnostics.Debug.WriteLine(projects);
            projects.Save(fileName);
            // Add the element.
            var query2 = from p in projects.Descendants(xmlns + "Project").Descendants(xmlns + "ItemGroup") where p.Descendants(xmlns + "Compile").Any() select p;
            if (query2.Any())
            {
                query2.Single().Add(new XElement(xmlns + "Compile", new XAttribute("Include", @"SerializedData\Tables.xml")));  
            }
            //System.Diagnostics.Debug.WriteLine(projects);
            projects.Save(fileName);
