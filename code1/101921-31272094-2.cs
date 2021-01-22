    ITargetInterface target = ObjectFactory.Create<TargetImplementation>(ParamList.Empty);
    target.DoSomething();
   
    var targetAsMixinA = target as IMixinInterfaceA;
    if (targetAsMixinA != null)
    {
       targetAsMixinA.MethodA();
    }
   
    var targetAsMixinB = target as IMixinInterfaceB;
    if (targetAsMixinB != null)
    {
        targetAsMixinB.MethodB(30);
    }
