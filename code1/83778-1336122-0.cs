       // Overload '+' for my class
       public static MyClass operator +(MyClass c1, MyClass c2) 
       {
          MyClass newMyClass = new MyClass();
          newMyClass.MyIntProperty = c1.MyIntProperty + c2.MyIntProperty;
          return newMyClass;
       }
