            var key = "ItemList";
            List<ItemAttribute> TempList = new List<ItemAttribute>();
            var value = HttpContext.Session.GetString(key);
            if (value != null)
            { TempList = JsonConvert.DeserializeObject<List<ItemAttribute>>(value); }
            var ItemAttribute1 = new ItemAttribute { UoM = ItemAttribute.UoM, SaleVal = ItemAttribute.SaleVal};
            TempList.Add(ItemAttribute1);
            
            ItemAttributeList = TempList;
            HttpContext.Session.SetString(key, JsonConvert.SerializeObject(ItemAttributeList));
            return Page();
