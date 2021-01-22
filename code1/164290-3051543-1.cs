    foreach (XmlElement elm in stats.SelectNodes("*"))
    {
       if (myTable.Columns.Contains(elm.Name))
       {
          DataColumn c = myTable.Columns[elm.Name];
          if (c.DataType == typeof(string))
          {          
             myRow[elm.Name] = elm.InnerText;
             continue;
          }
          if (c.DataType == typeof(double))
          {
             myRow[elm.Name] = Convert.ToDouble(elm.InnerText);
             continue;
          }
          throw new InvalidOperationException("I didn't implement conversion logic for " + c.DataType.ToString() + ".");
       }
    }
