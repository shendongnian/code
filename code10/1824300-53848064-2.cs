    // Retrieve the templates and store them into mailBodyTemplate and tableRowTemplate
    var tableRows = new StringBuilder();
    var totalPrice = 0;
    foreach (DataRow Row in Tables[0].Rows)
    {
        totalPrice += Convert.ToInt32(Row["Price"]);
        tableRows.AppendFormat(tableRowTemplate, Row["Name"], Row["UOM"], Row["Quantity"], Row["UnitPrice"], Row["Price"]);
    }
    var mailBody = string.Format(mailBodyTemplate, tableRows.ToString(), totalPrice);
    // Send your mail body
