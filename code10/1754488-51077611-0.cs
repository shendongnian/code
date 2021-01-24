    class HowToMap
        {
            private IEnumerable<Product> products;
            private IEnumerable<Color> colors;
    
            void Demo()
            {
                colors = products.SelectMany(r => r.Colors.Select(rr => new { r, rr.ColorEnum }))
                    .GroupBy(x => x.ColorEnum)
                    .Select(g => new Color { ColorEnum = g.Key, Products = g.Select(x => x.r).ToList() });
            }
        }
