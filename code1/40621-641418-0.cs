    public delegate void deleg(string msg);
    public class class1
    {
      public void method1(string msg)
      {
        //does something with msg
      }
      public void i_make_a_class2()
      {
        class2 bob = new class2(method1);
      }
    }
    public class class2
    {
      deleg deleg1;
      string im_a_String = "Test";
      public class2(deleg fct)
      {
        deleg1 = fct;
        // Rest of the class constructor...
      }
      private void method2()
      {
        deleg1(im_a_String);
      }
    }
