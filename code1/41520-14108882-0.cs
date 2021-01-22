    public partial class MyDataContext{
 
            [Function(Name = "NEWID", IsComposable = true)] 
            public Guid Random()
            { 
                // you can put anything you want here, it makes no difference 
                throw new NotImplementedException();
            }
    }
