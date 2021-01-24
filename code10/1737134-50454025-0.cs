    if (attribute != null)
    {
      builder.RegisterType(letterType)
             .Keyed<App.BusinessArea.NewBusiness.Letters.LetterBase>(attribute.LetterId);
    }
