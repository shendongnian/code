    var contacts = new List<Contacts>();
    
    for (int ndx = 0; ndx < trasactionCount; ndx++) {
      contacts.Add(new Contacts { ListAmount = TransactionsAmounts[ndx], ListDescription = TransactionsDescriptions[ndx] });
    }
    
    TransactionsList.ItemsSource = contacts;
