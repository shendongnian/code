        pyEngine = Python.CreateEngine();
                        pyScope = pyEngine.CreateScope();
                        var instance = pyEngine.Execute(@" 
                        def test(a,b): 
                        return a+b 
                        ", pyScope);
                        var test = pyScope.GetVariable<Func<int,int, int>>("test");
                        int s = test(2,3);
                        MessageBox.Show( Convert.ToString( test));
                        var ops = pyEngine.CreateOperations(pyScope);
