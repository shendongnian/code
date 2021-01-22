    public Pen CreatePenFromColor(Color c)
    {
        using (Brush b = new SolidBrush(c))
        { return new Pen(b); }
    }
