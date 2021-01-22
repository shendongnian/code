     #if !MSTEST
      using NUnit.Framework;
     #else
      using Microsoft.VisualStudio.TestTools.UnitTesting;
      using TestFixture = Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute;
      using Test = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
      using SetUp = Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute;
      using TearDown = Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute;
     #endif
