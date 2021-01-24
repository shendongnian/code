    private void ReceiveCategoryAddedMessage(CategoryAddedMessage message)
    {
        Categories.Add(message.AddedCategory);
    }
    
