    using NUnit.Framework;
    // ReSharper disable CheckNamespace
    
    [SetUpFixture]
    public class SingletonTeardown
    {
        [OneTimeTearDown]
        public void RunAfter()
        {
                if (SingletonType.Instance.IsValueCreated)
                {
                    SingletonType.Instance.Value.Dispose();
                }
            }
        }
    }
