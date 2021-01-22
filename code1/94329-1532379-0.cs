    [TestFixture]
    public class container_registration
    {
        [Test]
        public void session_request_should_be_scopped_per_httpcontext()
        {
            var container = new Container(new DataRegistry());
            
            var plugin = container.Model.PluginTypes.First(p => p.PluginType.UnderlyingSystemType == typeof(ISessionRequest));
            plugin.Lifecycle.ShouldBeOfType(typeof(HttpContextLifecycle));
        }
    }
