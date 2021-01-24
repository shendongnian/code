    static void Main(String[] args)
        {
            var data = "<listOfAdditionalReportingValues><additionalReportingValue>E</additionalReportingValue><additionalReportingValue>S</additionalReportingValue></listOfAdditionalReportingValues>";
            var xdoc = XDocument.Parse(data);
            var rootDescendents = xdoc.Root.Descendants();
            var elementDescendents = xdoc.Element("listOfAdditionalReportingValues").Descendants();
            rootDescendents.ToList().ForEach(x => Console.WriteLine(x));
            rootDescendents.ToList().ForEach(x => Console.WriteLine(x.Value));
            elementDescendents.ToList().ForEach(x => Console.WriteLine(x));
            elementDescendents.ToList().ForEach(x => Console.WriteLine(x.Value));
            Console.ReadLine();
        }
