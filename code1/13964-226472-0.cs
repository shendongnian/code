    //proxy
    public override void DoSomeStuff()
    {
         if(MethodHasTriggerAttribute)
            Trigger();
    
         _innerClass.DoSomeStuff();
    }
