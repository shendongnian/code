    private var GetDesserts()
    {
        return _icecreams.Select(
            i => new { icecream = i, topping = new Topping(i) }
        );
    }
    public void Eat()
    {
        foreach (var dessert in GetDesserts())
        {
            dessert.icecream.AddTopping(dessert.topping);
            dessert.Eat();
        }
    }
