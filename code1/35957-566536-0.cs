    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace SO566510
    {
        interface IMyProperties
        {
            int Property1 { get; set; }
            int Property2 { get; set; }
        }
        class SomeClassType1 : IMyProperties
        {
            public int Property1 { get; set; }
            public int Property2 { get; set; }
        }
        class SomeClassType2 : IMyProperties
        {
            public int Property1 { get; set; }
            public int Property2 { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var obj1 = new SomeClassType1();
                var obj2 = new SomeClassType2();
                FillObject(obj1, 10, 20);
                FillObject(obj2, 30, 40);
            }
            private static void FillObject(Object mainObject
                                       , int arg1, int arg2)
            {
                var objWithMyProperties = (IMyProperties)mainObject;
                objWithMyProperties.Property1 = arg1;
                objWithMyProperties.Property2 = arg2;
            }
        }
    }
