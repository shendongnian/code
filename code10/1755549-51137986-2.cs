    StringBuilder sb = new StringBuilder();
    
    using (var w = new ChoJSONWriter<PlaceObj>(sb)
    	.WithField(m => m.SkuNumber, valueConverter: (o) => String.Format("SKU_{0}", o.ToNString()))
    )
    {
    	PlaceObj o1 = new PlaceObj();
    	o1.Place = "1";
    	o1.SkuNumber = 100;
    
    	w.Write(o1);
    }
    
    Console.WriteLine(sb.ToString());
