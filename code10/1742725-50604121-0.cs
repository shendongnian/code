    GattCharacteristicProperties properties = characteristic.CharacteristicProperties;
                if (properties.HasFlag(GattCharacteristicProperties.Write) || properties.HasFlag(GattCharacteristicProperties.WriteWithoutResponse))
                {
                   //writing is supported..
                } 
