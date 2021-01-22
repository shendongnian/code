    MyBaseType : CLRType
    {
       public override void Execute(HttpContext context)
       {
           //Some code that's similar across CustomTypeOne, CustomTypeTwo etc
       }
       public void DoStuff()
       {
          //Same for all CustomTypes and can be part of a base class
       }
    }
    
    MyTypeA : MyBaseType
    {
        public void MyTypeACustomMethod()
        { 
          //do class specific logic here
        }
    }
    
    MyTypeB : MyBaseType
    {
        public void MyTypeBCustomMethod()
        { 
          //do class specific logic here
        }
    }
