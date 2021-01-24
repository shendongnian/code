        class JsonSerializerBaseObjectFactory
        {
        public enum Types
        {
            Article,
            Basket,
            Customer,
            WishList,
            User,
            Tarif,
            Store,
            Stock,
            ShippingTaxe,
            Seller,
            SalesDocument,
            Promotion,
            Payment,
            InventoryTransaction,
            Inventory,
            Family,
            Etablissement,
            Dimension,
            Depot,
            CreditCard,
            Country,
            Commande,
            Category,
            Cashier,
            AvailableQuantity,
            ArticleRequest
        };
        public static BaseDto DeserializeObject(string type, JsonReader reader, JsonSerializer serializer)
        {
            Types typeRes;
            if (Enum.TryParse(type, out typeRes))
            {
                switch (typeRes)
                {
                    case Types.Article:
                        return serializer.Deserialize<ArticleDto>(reader);
                    case Types.Basket:
                        return serializer.Deserialize<BasketDto>(reader);
                    case Types.Customer:
                        return serializer.Deserialize<CustomerDto>(reader);
                    default:
                        return serializer.Deserialize<BaseDto>(reader);
                }
            }
            return serializer.Deserialize<BaseDto>(reader);
        }
        }
