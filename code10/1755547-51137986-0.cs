    StringBuilder sb = new StringBuilder();
    
    using (var w = new ChoJSONWriter(sb)
    	.WithField("Place")
    	.WithField("SkuNumber", valueConverter: (o) => String.Format("SKU_{0}", o.ToNString()))
    	)
    {
    	dynamic o1 = new ExpandoObject();
    	o1.Place = 1;
    	o1.SkuNumber = 100;
    
    	w.Write(o1);
    }
    
    Console.WriteLine(sb.ToString());
