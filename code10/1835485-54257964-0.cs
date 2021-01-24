          namespace readingvaraibles
         {
             public class Class1
            {
               public Class2 Class2 {get;set}
               public Class3 Class3 {get;set;
            }
         }
         var class1 = new Class1();
         var class2 = new class1.Class2();
         var variable1 = class2.variable_1;
         var variable2 = class2.variable_2;
         var class3 = new class1.Class3();
         var variable3 = class3.variable3;
