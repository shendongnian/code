          var lookup = new Dictionary<int, Coin>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var result = await conn.QueryAsync<Coin, CoinCategoryCategory, CoinCategory, Coin>(
                    @"SELECT c.*, coinCat.*, cat.*
                        FROM Coins c
                        INNER JOIN CoinCategoriesCategories coinCat ON coinCat.CoinId = c.CoinId
                        INNER JOIN CoinCategories cat ON cat.CategoryId = coinCat.CategoryID", 
                    (c, cat, coinCat) =>
                    {
                        Coin coin;
                        if (!lookup.TryGetValue(c.CoinId, out coin))
                        {
                            lookup.Add(c.CoinId, coin = c);
                        }
                        if (coin.Categories == null)
                            coin.Categories = new List<CoinCategory>();
                        coin.Categories.Add(new CoinCategory { CategoryId = coinCat.CategoryId, Description = coinCat.Description });
                        return coin;
                    }, splitOn: "CategoryId, CoinId");
                return lookup.Values;
            }
