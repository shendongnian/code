    ClassA a = new ClassA();
    using (XmlTextReader reader = new XmlTextReader("books.xml"))
				{
					
					while (reader.Read())
					{
						switch (reader.Name)
						{
							case "text":
								//do something with this node, like:
                                a.Name = reader.Value;
								break;
						}
					}
				}
