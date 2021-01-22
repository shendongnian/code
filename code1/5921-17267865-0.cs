    var UpdatedGiftItem = // object value to update;
    
    foreach (var proInfo in UpdatedGiftItem.GetType().GetProperties())
    {
        var updatedValue = proInfo.GetValue(UpdatedGiftItem, null);
        var targetpropInfo = this.GiftItem.GetType().GetProperty(proInfo.Name);
        targetpropInfo.SetValue(this.GiftItem, updatedValue,null);
    }
