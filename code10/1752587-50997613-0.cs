    interface IDataMoldVisitor
    {  void visit(DataMold<string> dataMold);
       void visit(DataMold<int> dataMold);
    }
    // Console.WriteLine for all
    class DataMoldConsoleWriter : IDataMoldVisitor
    {  public void visit(DataMold<string> dataMold)
       {  Console.WriteLine(dataMold.Result);
       }
       public void visit(DataMold<int> dataMold)
       {  Console.WriteLine(dataMold.Result);
       }
    }
