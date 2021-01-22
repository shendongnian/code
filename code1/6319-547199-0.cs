     #if !MSTEST
      using NUnit.Framework;
     #else
      using Microsoft.VisualStudio.TestTools.UnitTesting;
      using TestFixture = Microsoft.VisualStudio.TestTools.TestClassAttribute;
      using Test = Microsoft.VisualStudio.TestTools.TestMethodAttribute;
      using SetUp = Microsoft.VisualStudio.TestTools.TestInitializeAttribute;
      using TearDown = Microsoft.VisualStudio.TestTools.TestCleanupAttribute;
     #endif
