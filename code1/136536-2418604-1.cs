    static void Main(string[] args)
		{
			XElement xElement = XElement.Load(@"C:\Labs\test.xml");
			// PartitionName="AIX" is belonging to Type="NIC"
			var count = xElement.Descendants().Where(x => x.Name.ToString().Contains("Port")) // namespaces might be used here for faster traversal..
						.Where(x => x.HasAttributes && x.Attribute("Type").Value == "NIC")
						.Descendants().Where(x => x.Name.ToString().Contains("Client"))
						.Where(x => x.Attribute("PartitionName").Value == "AIX").Count();		
			string str = count.ToString();
			Console.WriteLine("Count = {0}", str);
			Console.ReadLine();				 
			
		}
