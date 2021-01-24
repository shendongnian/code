    public class MyTypeVm
    {
       public string MyStringProperty {get;set}
       public int MyIntProperty {get;set}
       public override string ToString()
       {
         return MyStringProperty + MyIntProperty.ToString();
       }  
    }
