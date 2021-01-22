    using System.Linq.Expressions;
    using System.Reflection;
    
    
    NewExpression newSubClient = Expression.New(typeof(SubClient));
    Console.WriteLine(newSubClient.ToString());
    
    List<MemberBinding> bindings = new List<MemberBinding>();
    ParameterExpression paramExpr = Expression.Parameter(typeof(Client), "c");
    MemberInfo idMember = typeof(SubClient).GetMember("Id")[0];
    MemberBinding idBinding = Expression.Bind(
      idMember,
      Expression.Property(paramExpr, "id")
    );
    Console.WriteLine(idBinding.ToString());
    
    //save it for later
    bindings.Add(idBinding);
    
    if (filterByA)
    {
      MemberInfo aMember = typeof(SubClient).GetMember("a")[0];  
      MemberBinding aBinding = Expression.Bind(
        aMember,
        Expression.Property(paramExpr, "a")
      );
      Console.WriteLine(aBinding.ToString());
    
      //save it for later
      bindings.Add(aBinding);
    }
    if (filterByB)
    {
      MemberInfo bMember = typeof(SubClient).GetMember("b")[0];
      MemberBinding bBinding = Expression.Bind(
        aMember,
        Expression.Property(
          Expression.Property(
            Expression.Property(
              Expression.Property(paramExpr, "e")
            , "f")
          , "g")
        , "b")
      );
      Console.WriteLine(bBinding.ToString());
    
      //save it for later
      bindings.Add(bBinding);
    }
    
    MemberInitExpression newWithInit = Expression.MemberInit
    (
      newSubClient,
      bindings  //use any bindings that we created.
    );
    Console.WriteLine(newWithInit.ToString());
    Expression<Func<Client, SubClient>> result =
      Expression.Lambda<Func<Client, SubClient>>
      (
        newWithInit,
        paramExpr
      );
    
    Console.WriteLine(result);
    return result;
