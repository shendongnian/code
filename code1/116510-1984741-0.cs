    // Create the document.
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
    
            // Loop through all the nodes, and create the list of Product objects .
            List<Product> products = new List<Product>();
    
            foreach (XmlElement element in doc.DocumentElement.ChildNodes)
            {
                Product newProduct = new Product();
                newProduct.ID = Int32.Parse(element.GetAttribute("ID"));
                newProduct.Name = element.GetAttribute("Name");
    
                // If there were more than one child node, you would probably use
                // another For Each loop here and move through the
                // Element.ChildNodes collection.
                newProduct.Price = Decimal.Parse(element.ChildNodes[0].InnerText);
    
                products.Add(newProduct);
            }
