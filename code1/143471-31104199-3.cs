       using System;
       using System.Collections.Generic;
       using NUnit.Framework;
       using Newtonsoft.Json;
       namespace FindNthNamespace.Tests
       {
           public class fNTests
           {
               [TestCase("pass", "dtststx", 't', 3, Result = "{\"t\":\"t\",\"index\":5}")]
               [TestCase("pass", new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            0, 2, Result="{\"t\":0,\"index\":10}")]
               public string fNMethodTest<T>(string scenario, IEnumerable<T> tc, T t, int occurrencePosition) where T : IEquatable<T>
               {
                   Console.WriteLine(scenario);
                   return JsonConvert.SerializeObject(fNns.fN.findNth<T>(tc, t, occurrencePosition)).ToString();
               }
               [TestCase("pass", "dtststxx", 't', 3, Result = "{\"t\":\"t\",\"index\":6}")]
               [TestCase("pass", new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            0, 2, Result = "{\"t\":0,\"index\":19}")]
               public string fNMethodTestReverse<T>(string scenario, IEnumerable<T> tc, T t, int occurrencePosition) where T : IEquatable<T>
               {
                   Console.WriteLine(scenario);
                   return JsonConvert.SerializeObject(fNns.fN.findNthReverse<T>(tc, t, occurrencePosition)).ToString();
               }
    }
}
