     public void ReferenceExample(SomeReferenceType s)
     {
       s.SomeProperty = "a string"; // The change is persisted to outside of the method
     }
     public void ValueTypeExample(BigStruct b)
     {
       b.A = 5; // Has no effect on the original BigStruct that you passed into the method, because b is a copy!
     }
     public void ValueTypeExampleOut(out BigStruct b)
     {
       b = new BigStruct();
       b.A = 5; // Works, because you refer to the same thing here
     }
