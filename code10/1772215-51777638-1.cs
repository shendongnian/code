    public void Init()
        {
            outputter = new TextBoxOutputter(TestBox);
            Console.SetOut(outputter);
        }
