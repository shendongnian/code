    public class UniRebinder : ExpressionVisitor
    {
        readonly Func<Expression, Expression> replacement;
        UniRebinder(Func<Expression, Expression> replacement)
        {
            this.replacement = replacement;
        }
        public static Expression Replace(Expression exp, Func<Expression, Expression> replacement)
        {
            return new UniRebinder(replacement).Visit(exp);
        }
        public override Expression Visit(Expression p)
        {
            return base.Visit(replacement(p));
        }
    }
    Expression<Func<Item, ItemDTO>> ReplaceProperty(
        int setting, Expression<Func<Item, ItemDTO>> value)
    {
        Func<MemberExpression, Expression> SettingSelector(int ss)
        {
            switch (ss)
            {
                case 1: return x => Expression.MakeMemberAccess(x.Expression, typeof(Item).GetProperty(nameof(Item.NormalDescription)));
                case 2: return x => Expression.MakeMemberAccess(x.Expression, typeof(Item).GetProperty(nameof(Item.LongDescription)));
                case 3: return x => Expression.MakeMemberAccess(x.Expression, typeof(Item).GetProperty(nameof(Item.ShortDescription)));
                default: return x => Expression.Constant(String.Empty);
            }
        }
        return (Expression<Func<Item, ItemDTO>>)UniRebinder.Replace(
            value,
            x =>
            {
                if (x is MemberExpression memberExpr
                    && memberExpr.Member.Name == nameof(Item.NormalDescription))
                {
                    return SettingSelector(setting)(memberExpr);
                }
                return x;
            });
    }
    private void Test()
    {
        var repo = (new List<Item>() {
            new Item() {
                ItemId ="1",
                LongDescription = "longd1",
                NormalDescription = "normald1",
                ShortDescription = "shortd1" },
            new Item() {
                ItemId ="2",
                LongDescription = "longd2",
                NormalDescription = "normald2",
                ShortDescription = "shortd2" }
        }).AsQueryable();
        for (int selector = 1; selector < 5; ++selector)
        {
            var tst = repo.Select(ReplaceProperty(selector,
                i => new ItemDTO
                {
                    Id = i.ItemId,
                    DisplayName = i.NormalDescription
                })).ToList();
            Console.WriteLine(selector + ": " + string.Join(", ", tst.Select(x => x.DisplayName)));
            //Output:
            //1: normald1, normald2
            //2: longd1, longd2
            //3: shortd1, shortd2
            //4: , 
        }
    }
