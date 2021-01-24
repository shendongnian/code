    foreach(PLYOrder p in t.Item2)
    { 
    	writer.WriteStartElement("Scheds");
    	writer.WriteAttributeString("Qty", p.Qty.ToString());
    	writer.WriteAttributeString("ProdId", p.Product.Id.ToString());
    	writer.WriteAttributeString("Comments", p.Comments);
    	writer.WriteEndElement();
    }
