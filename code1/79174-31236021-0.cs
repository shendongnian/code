        List<Cat> cats = new List<Cat>
        {
            new Cat(){ Name = "Sylvester", Age=8 },
            new Cat(){ Name = "Whiskers", Age=2 },
            new Cat(){ Name = "Sasha", Age=14 }
        };
        Session["data"] = cats;
        foreach (Cat c in cats)
            System.Diagnostics.Debug.WriteLine("Cats>>" + c.Name);     //DEBUGGG
