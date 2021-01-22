    // returns: The type name 'NewLine' does not 
    // exist in the type 'System.Environment' error
    using NL = System.Environment.NewLine;
Overloaded operator is an interesting idea, but then you'll have to use something other than a String.  Usually people create a struct which can take a base string value and then overload the operators.  Not worth the pain if all you want to do is replace the Environment.NewLine.  You're better off to use a static extension as suggested by others.  
Another alternative (if you're dead set on using NL) is to descend all the classes in your framework off of a common parent class which can have the following property:
    public class BaseParentClass
    {
      public string NL
      {
        get { return System.Environment.NewLine; }
      }
    }
