            JsonConverter collectionItemConverter = GetConverter(contract.ItemContract, null, contract, containerProperty);
            int? previousErrorIndex = null;
            bool finished = false;
            do
            {
                try
                {
                    if (reader.ReadForType(contract.ItemContract, collectionItemConverter != null))
                    {
                        switch (reader.TokenType)
                        {
                            case JsonToken.EndArray:
                                finished = true;
                                break;
                            case JsonToken.Comment:
                                break;
                            default:
                                object value;
                                if (collectionItemConverter != null && collectionItemConverter.CanRead)
                                {
                                    value = DeserializeConvertable(collectionItemConverter, reader, contract.CollectionItemType, null);
                                }
            
