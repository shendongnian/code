    [TestMethod]
    public void TestMethod ()
    {
        StringWriter writer = new StringWriter ();
        Sequence sequence = new Sequence
        {
            Activities =
            {
                new WriteLine 
                {
                    Text = "Hello", 
                    TextWriter = new LambdaValue<TextWriter> (n => writer) 
                },
                new WriteLine 
                {
                    Text = "World", 
                    TextWriter = new LambdaValue<TextWriter> (n => writer) 
                }
            }
        };
        WorkflowInvoker.Invoke (sequence);
        Assert.
            AreEqual (
            "Hello\r\nWorld\r\n", 
            writer.GetStringBuilder ().ToString ());
    }
