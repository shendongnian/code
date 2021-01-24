    IGraph g = new Graph();
    //Define the Namespaces we want to use
    g.NamespaceMap.AddNamespace("rdf", new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#"));
    g.NamespaceMap.AddNamespace("ex", new Uri("http://example.org/"));
    //Define the same Triple as the previous example
    UriNode rdfType = g.CreateUriNode("rdf:type");
    UriNode exThis = g.CreateUriNode("ex:Carnivore");
