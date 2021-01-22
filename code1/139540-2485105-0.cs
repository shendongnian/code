container.RegisterType&lt;Bot&gt;(new ContainerControlledLifecycleManager()); // from my memory...
container.RegisterType&lt;IAccessManager,MyAccessManager&gt;();
var bot = container.Resolve&lt;Bot&gt;();
// Bot.cs
public Bot(IAccessManager manager)
{
   manager.InitializeFor(this);
}
