    [Test]
    public void AssemblyLoadRegisterFromXml() {
        var container = new WindsorContainer();
        AppDomain.CurrentDomain.AssemblyLoad += (sender, args) => {
            var filename = args.LoadedAssembly.FullName.Split(',')[0] + ".xml";
            container.Install(Configuration.FromXmlFile(filename));
        }; ;
        Assembly.Load("System.Transactions, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
        var ex = container.Resolve(Type.GetType("System.Transactions.TransactionException, System.Transactions, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        Assert.AreEqual("hello world", ex.GetType().GetProperty("Message").GetValue(ex, null));
    }
