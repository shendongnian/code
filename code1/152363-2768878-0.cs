    //base parameter type - provides the 'anchor' for our generic constraint later, 
    //as well as a nice, strong-typed access to our param values.
    public class StaticParameterBase
    {
      public abstract string ParameterString{ get; }
      public abstract MyComplexType ParameterComplex { get; }
    }
    //note the use of the new() generic constraint so we know we can confidently create
    //an instance of the type.
    public class MyType<TParameter> where TParameter:StaticParameterBase, new()
    {
      //local copies of parameter values.  Could also simply cache an instance of
      //TParameter and wrap around that. 
      private static string ParameterString { get; set; }
      private static MyComplexType ParameterComplex { get; set; }
      static MyType()
      {
        var myParams = new TParameter();
        ParameterString = myParams.ParameterString;
        ParameterComplex = myParams.ParameterComplex;
      }
    }
    //e.g, a parameter type could be like this:
    public class MyCustomParameterType : StaticParameterBase
    { 
      public override string ParameterString { get { return "Hello crazy world!"; } }
      public override MyComplexType { get {
          //or wherever this object would actually be obtained from.
          return new MyComplexType() { /*initializers etc */ };
        }
      }
    }
    //you can also now derive from MyType<>, specialising for your desired parameter type
    //so you can hide the generic bit in the future (there will be limits to this one's
    //usefulness - especially if new constructors are added to MyType<>, as they will 
    //have to be mirrored on this type as well).
    public class MyType2 : MyType<MyCustomParameterType> { }
    //then you'd use the type like this:
    public static void main()
    {
      var instance = new MyType<MyCustomParameterType>();
      //or this:
      var instance2 = new MyType2();
    }
    
