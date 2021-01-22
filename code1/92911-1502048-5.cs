    static class Program
    {
        static void Main() {
            var favs = new FavouriteSettings
            {
                bigList = new List<FavouriteList>
                {
                    new FavouriteList {
                        Name = "Customer",
                        aList = new List<int>{
                            12,2,5
                        }
                    }, new FavouriteList {
                        Name = "Supplier",
                        aList = new List<int>{
                            158, 23, 598
                        }
                    }
                }
            };
            var el = new XElement("FavoriteSettings",
                from fav in favs.bigList
                select new XElement(fav.Name,
                    from item in fav.aList
                    select new XElement("ID", item)));
            string xml = el.ToString();
            Console.WriteLine(xml);
            el = XElement.Parse(xml);
            favs = new FavouriteSettings
            {
                bigList = new List<FavouriteList>(
                    from outer in el.Elements()
                    select new FavouriteList
                    {
                        Name = outer.Name.LocalName,
                        aList = new List<int>(
                            from id in outer.Elements("ID")
                            select (int)id
                        )
                    })
            };
        }
    }
