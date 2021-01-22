    void DoSomething(Func<Bitmap> imageProvider)
    {
        using (Bitmap image = imageProvider())
        {
            // Code here
        }
    }
    ...
    DoSomething(() => RetrieveImage());
