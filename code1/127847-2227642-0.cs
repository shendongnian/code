    internal class SomeClass
    {
       public override String ToString()
       {
           // The "return base.ToString()" call could produce one of these two possibilities:
           // This will NOT go through the class hierarchy, searching for a overwritten function
           // called ToString
           call and return System.Object::ToString()
           // But this WILL, thus calling SomeClass::ToString() recursively, so this is wrong
           // and would lead to a stack overflow
           callvirt and return System.Object::ToString()
       }
    }
