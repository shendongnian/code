     foreach (var character in characteristics.Characteristics)
     {
       GattCharacteristicProperties properties = character.CharacteristicProperties;
                        if (properties.HasFlag(GattCharacteristicProperties.Read))
                        {
                           var result = await character.ReadValueAsync();
                           var reader = DataReader.FromBuffer(result.Value);
                           var input = new byte[reader.UnconsumedBufferLength];
                           reader.ReadBytes(input);
                           Debug.WriteLine(BitConverter.ToString(input));
                           Debug.WriteLine("Characteristic Handle: " +
                                      character.AttributeHandle + ", UUID: " +
                                      character.Uuid);
                        }
                       // these are other sorting flags that can be used so sort characterisics.
                        if (properties.HasFlag(GattCharacteristicProperties.Write))
                        {
                           Debug.Write("This characteristic supports writing.");
                        }
                        if (properties.HasFlag(GattCharacteristicProperties.Notify))
                        {
                           Debug.Write("This characteristic supports subscribing to notifications.");
                        }
                        
     }
                  
