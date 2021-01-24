       public void UpdateRecipients(IEnumerable<Recipient> newRecipients)
       {
           Recipients.Clear();
           
           foreach (var item in newRecipients)
           {
               Recipients.Add(item);
           }
       }
