    using KellermanSoftware.CompareNetObjects;
    using System;
    namespace MyProgram.UnitTestHelper
    {
      public class ObjectComparer
      {
        public static bool ObjectsHaveSameValues(object first, object second)
        {
          CompareLogic cl = new CompareLogic();
          ComparisonResult result = cl.Compare(first, second);
          if (!result.AreEqual)
            Console.WriteLine(result.DifferencesString);
          return result.AreEqual;
        }
      }
    }
