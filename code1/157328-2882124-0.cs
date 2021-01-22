      using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        
        namespace TestFactoryPattern
        {
            public abstract class Input
            {
                public int Val;
            }
        
            public class InputObjA : Input
            {
                public InputObjA()
                {
                    Val = 1;
                }
            }
        
            public class InputObjB : Input
            {
                public InputObjB()
                {
                    Val = 2;
                }
            }
        
            public abstract class MyXmlWriter
            {
                public static int InputVal;
        
                public static MyXmlWriter Create(Input input)
                {
                    InputVal = input.Val;
        
                    if (input is InputObjA)
                    {
                        return new MyObjAXmlWriter();
                    }
                    else if (input is InputObjB)
                    {
                        return new MyObjBXmlWriter();
                    }
                    else
                    {
                        return new MyObjAXmlWriter();
                    }
                }
        
                public abstract void WriteMyXml();
            }
        
            public class MyObjAXmlWriter : MyXmlWriter
            {
                public override void WriteMyXml()
                {
                    Console.WriteLine("Input A Written: " + InputVal);
                }
            }
        
            public class MyObjBXmlWriter : MyXmlWriter
            {
                public override void WriteMyXml()
                {
                    Console.WriteLine("Input B Written: " + InputVal);
                }
            }
        
            public class Program
            {
                public static void Main()
                {
                    InputObjA a = new InputObjA();
        
                    MyXmlWriter myXml1 = MyXmlWriter.Create(a);
        
                    myXml1.WriteMyXml();
        
                    InputObjB b = new InputObjB();
        
                    MyXmlWriter myXml2 = MyXmlWriter.Create(b);
        
                    myXml2.WriteMyXml();
        
                }
          
    
      }
    }
