    public List<string> GetProductCategories(int catno)
    {
        string catName = string.Format("Category{0}", catno);
        using (var ctx = new myEntities())
        {
            var result = ctx.Categories.Select(x => {
                    var prop = x.GetType().GetProperty(catName);
                    if (prop == null)
                    {
                        return double.NaN;
                    }
                    return double.Parse(prop.GetValue(x).ToString());
                }).ToList();
            return result.Where(x => !double.IsNaN(x)).ToList();
        }
    }
