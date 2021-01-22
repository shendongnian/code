    void SetValueExample( string propName, string valueToUse )
    {
      Shipment shipment = new Shipment();
      Type type = shipment.GetType();
      PropertyInfo senderProperty = type.GetProperty(propName);
      senderProperty.SetValue(shipment, valueToUse, null );
    }
