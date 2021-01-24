      // static: we don't want to mention pesky MyEnvironmentVariables
      using static MyNameSpace.MyEnvironmentVariables;
    
      ...
      public class MyDifferentWindow {
        ...
        public void MyMethod() {
          // we can use EmployerId as if it's a global variable
          int id = EmployerId;
          ... 
