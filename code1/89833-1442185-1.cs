    namespace NUnit.Tests
    {
      using System;
      using NUnit.Framework;
    
      [TestFixture]
      public class SuccessTests
      {
        [TestFixtureSetUp] public void Init()
        { /* ... */ }
    
        [TestFixtureTearDown] public void Dispose()
        { /* ... */ }
    
        [Test] public void Add()
        { /* ... */ }
      }
    }
