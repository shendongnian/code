    void Add<TDrawing>(TDrawing item, IList<TDrawing> list)
        where TDrawing : IDrawing
    {
        if (item.SomePropertyOfIDrawing)
        {
            list.Add(item);
        }
    }
