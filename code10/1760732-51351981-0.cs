     private void OrderPizza()
     {
        Outlook.MailItem mail = (Outlook.MailItem)Application.CreateItem(
           Outlook.OlItemType.olMailItem);
        mail.VotingOptions = “Cheese; Mushroom; Sausage; Combo; Veg Combo;”
        mail.Subject = “Pizza Order”;
        mail.Display(false);
     }
