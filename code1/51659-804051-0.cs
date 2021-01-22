    public IEnumerable<object[]> GetValues(TextReader reader, PrimitiveType[] schema)
    {
       while (reader.Peek() > 0)
       {
           var values = new object[schema.Length];
           for (int i = 0; i < schema.Length; ++i)
           {
               switch (schema[i])
               {
                   case PrimitiveType.BIT:
                       values[i] = ScanBit(reader);
                       break;
                   case PrimitiveType.DATE:
                       values[i] = ScanDate(reader);
                       break;
                   case PrimitiveType.FLOAT:
                       values[i] = ScanFloat(reader);
                       break;
                   case PrimitiveType.INTEGER:
                       values[i] = ScanInt(reader);
                       break;
                   case PrimitiveType.STRING:
                       values[i] = ScanString(reader);
                       break;
               }
           }
           EatTabs(reader);
           if (reader.Peek() == '\n')
           {
                break;
           }
       }
       
       if (reader.Peek() == '\n')
       {
           reader.Read();
       }
       else if (reader.Peek() >= 0)
       {
           throw new Exception("Extra junk detected!");
       }
       yield return values;
       }
       reader.Read();
    }
