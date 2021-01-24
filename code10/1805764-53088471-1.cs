    private static bool ValidateAmount(string json, Func<int, bool> validateFunc)
    {
        using (JsonTextReader reader = new JsonTextReader(new StringReader(json)))
        {
            reader.CloseInput = true;
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName && reader.Value.Equals("amount"))
                {
                    int? amount = reader.ReadAsInt32();
                    if (!amount.HasValue)
                    {
                        return false;
                    }
                    bool isValid = validateFunc(amount.Value);
                    return isValid;
                }
            }
        }
        return false;
    }
