    this.CartItems.Where(item => item.EffectivePrice != null).ToList().ForEach
    (
       item =>
          item.EffectivePrice = CurrencyHelper.GetLocalizedCurrency(item.EffectivePrice);
    );
