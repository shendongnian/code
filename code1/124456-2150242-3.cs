    void MyFunction()
    {
        using (Bitmap image = RetrieveImage())
        {
            DoSomething(image);
        }
    }
