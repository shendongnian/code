     GattCharacteristicProperties properties = charac.CharacteristicProperties;
    
                               if (properties.HasFlag(GattCharacteristicProperties.Read))
                               {
                                  Debug.WriteLine("This characteristic supports reading from it.");                              
                               }
                               if (properties.HasFlag(GattCharacteristicProperties.Write))
                               {
                                  Debug.WriteLine("This characteristic supports writing it.");                              
                               }
                               if (properties.HasFlag(GattCharacteristicProperties.Notify))
                               {
                                  Debug.WriteLine("This characteristic supports subscribing to notifications.");
                               }
                               if (properties.HasFlag(GattCharacteristicProperties.Indicate))
                               {
                                  Debug.WriteLine("This characteristic supports subscribing to Indication");
                               }
