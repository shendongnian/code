    private Func<TransactionScope> _getCurrentScopeDelegate;
    
    bool IsInsideTransactionScope
    {
      get
      {
        if (_getCurrentScopeDelegate == null)
        {
          _getCurrentScopeDelegate = CreateGetCurrentScopeDelegate();
        }
        TransactionScope ts = _getCurrentScopeDelegate();
        return ts != null;
      }
    }
    private Func<TransactionScope> CreateGetCurrentScopeDelegate()
    {
      DynamicMethod getCurrentScopeDM = new DynamicMethod(
        "GetCurrentScope",
        typeof(TransactionScope),
        null,
        this.GetType(),
        true);
      Type t = typeof(Transaction).Assembly.GetType("System.Transactions.ContextData");
      MethodInfo getCurrentContextDataMI = t.GetProperty(
        "CurrentData", 
        BindingFlags.NonPublic | BindingFlags.Static)
        .GetGetMethod(true);
      FieldInfo currentScopeFI = t.GetField("CurrentScope", BindingFlags.NonPublic | BindingFlags.Instance);
      ILGenerator gen = getCurrentScopeDM.GetILGenerator();
      gen.Emit(OpCodes.Call, getCurrentContextDataMI);
      gen.Emit(OpCodes.Ldfld, currentScopeFI);
      gen.Emit(OpCodes.Ret);
      return (Func<TransactionScope>)getCurrentScopeDM.CreateDelegate(typeof(Func<TransactionScope>));
    }
    [Test]
    public void IsInsideTransactionScopeTest()
    {
      Assert.IsFalse(IsInsideTransactionScope);
      using (new TransactionScope())
      {
        Assert.IsTrue(IsInsideTransactionScope);
      }
      Assert.IsFalse(IsInsideTransactionScope);
    }
