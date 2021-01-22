    /// <summary>
    /// Use on a (possibly abstract) method or property to indicate that all subclasses must provide their own implementation.
    /// 
    /// This is stronger than just abstract, as when you have
    /// 
    /// A { public abstract void Method()}
    /// B: A { public override void Method(){} }
    /// C: B {} 
    /// 
    /// C will be marked as an error
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public class AllSubclassesMustOverrideAttribute : Attribute
    {
         
    }
    [TestFixture]
    public class AllSubclassesMustOverrideAttributeTest
    {
        [Test]
        public void SubclassesOverride()
        {
            var failingClasses = new List<string>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    foreach (var type in assembly.GetTypes())
                    {
                        foreach (var methodInfo in type.GetMethods().Where(m => m.HasAttributeOfType<AllSubclassesMustOverrideAttribute>()))
                        {
                            foreach (var subClass in type.ThisTypeAndSubClasses())
                            {
                                var subclassMethod = subClass.GetMethod(methodInfo.Name);
                                if (subclassMethod.DeclaringType != subClass)
                                {
                                    failingClasses.Add(string.Format("Class {0} has no override for method {1}", subClass.FullName, methodInfo.Name));
                                }
                            }
                        }
                        foreach (var propertyInfo in type.GetProperties().Where(p => p.HasAttributeOfType<AllSubclassesMustOverrideAttribute>()))
                        {
                            foreach (var subClass in type.ThisTypeAndSubClasses())
                            {
                                var subclassProperty = subClass.GetProperty(propertyInfo.Name);
                                if (subclassProperty.DeclaringType != subClass)
                                {
                                    failingClasses.Add(string.Format("Class {0} has no override for property {1}", subClass.FullName, propertyInfo.Name));
                                }
                            }
                            
                        }
                    }
                }
                catch (ReflectionTypeLoadException)
                {
                    // This will happen sometimes when running the tests in the NUnit runner. Ignore.
                }
            }
            if (failingClasses.Any())
            {
                Assert.Fail(string.Join("\n", failingClasses));
            }
        }
    }
