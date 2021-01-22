 #if !NUNIT
  using Microsoft.VisualStudio.TestTools.UnitTesting;
 #else
  using NUnit.Framework;
  using TestClass = NUnit.Framework.TestFixtureAttribute;
  using TestMethod = NUnit.Framework.TestAttribute;
  using TestInitialize = NUnit.Framework.SetUpAttribute;
  using TestCleanup = NUnit.Framework.TearDownAttribute;
  using TestContext = System.String;
  using DeploymentItem = NUnit.Framework.DescriptionAttribute;
 #endif
