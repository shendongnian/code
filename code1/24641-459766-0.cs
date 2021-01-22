     RetailAccountCustomerCard racc = new RetailAccountCustomerCard();
    
     Card addedCard = _idc.Cards.Where(c => c.CardId == card.CardId).ToList().First();
    
     racc.Card = addedCard;
    
     this.CurrentCustomer.RetailAccountCardsBindingList.Add(racc); 
    
     // Some code triggered by the user before saving to the db
    
     CurrentCustomer.RetailAccountCardsBindingList.Remove(racc);
