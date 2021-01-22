    foreach (var order in customerOrderHistory)
        {
            TableRow rowCopy = (TableRow)theRow.CloneNode(true);
            rowCopy.Descendants<TableCell>().ElementAt(0).Append(new Paragraph 
                (new Run (new Text(order.Contact.ToString()))));
            rowCopy.Descendants<TableCell>().ElementAt(1).Append(new Paragraph 
                (new Run (new Text(order.NameOfProduct.ToString()))));
            rowCopy.Descendants<TableCell>().ElementAt(2).Append(new Paragraph 
                (new Run (new Text(order.Amount.ToString()))));
            theTable.AppendChild(rowCopy);
         }
