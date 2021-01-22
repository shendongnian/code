    using (MyQueryClass myQuery = new MyQueryClass())
    {
       myQuery.Command("Update...").ParamVal("@P1", 1).ParamVal("@P2", 2).Execute();
       return myQuery.Command("Select ...").ParamVal("@Param", SomeVal).ReturnList<SomeType>();
    }
