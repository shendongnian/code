    [TestFixture]
    public class SecurityExperiments
    {
        [Test]
        public void ShouldGetCustomSecurityAttributes()
        {
            Assert.That(typeof (Applied).GetCustomAttributes(true),
                        Has.Some.InstanceOf<PluginSection>());
        }
        public class PluginSection : CodeAccessSecurityAttribute
        {
            public PluginSection(SecurityAction action)
                : base(action)
            {
            }
            public override IPermission CreatePermission()
            {
                // Removed for demo purposes
                return null;
            }
        }
        [PluginSection(SecurityAction.Demand)]
        class Applied { }
    }
