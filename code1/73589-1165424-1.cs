    switch(action) {
        case EnumDeliveryAction.Email; RunEmail(); break;
        case EnumDeliveryAction.SharePoint; RunSharePoint(); break;
        default: throw new InvalidOperationException(
              "Unexpected action: " + action);
    }
