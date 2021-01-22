     public void Add(params Object[] inputs)
     {
         Int32 numberPairs = inputs.Length / 2;
         KeyValue[] keyValues = new KeyValue[numberPairs];
         for (Int32 i = 0; i < numberPairs; i++)
         {
             Int32 key = (Int32)inputs[2 * i];
             String value = (String)inputs[2 * i + 1];
             keyvalues[i] = new KeyValue(key, value);
         }
         // Call the overloaded method accepting KeyValue[].
         this.Add(keyValues);
     }
     public void Add(params KeyValue[] values)
     {
         // Do work here.
     }
