    FieldInfo stateInfo = args.GetType().GetField("State");
    Object myClassObj = stateInfo.GetValue(args);
    PropertyInfo errorMessagesInfo = myClassObj.GetType().GetProperty("ErrorMessages");
    object errorMessagesObj = errorMessagesInfo.GetValue(myClassObj, null);
    IList errorMessages = errorMessagesObj as IList;
