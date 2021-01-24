    interface IDataMoldAcceptor
    {  void accept(IDataMoldVisitor visitor);
    }
    abstract class DataMold<T> : IDataMoldAcceptor
    {  public abstract T Result { get; }
       public abstract void accept(IDataMoldVisitor visitor);
    }
    class TextMold : DataMold<string>
    {  public string Result => "ABC";
       public override void accept(IDataMoldVisitor visitor)
       {  visitor.visit(this);
       }
    }  
    class NumberMold : DataMold<int>
    {  public int Result => 123;
       public override void accept(IDataMoldVisitor visitor)
       {  visitor.visit(this);
       }
    }
