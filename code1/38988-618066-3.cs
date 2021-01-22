IUnityContainer container = new UnityContainer();
container.RegisterType&lt;Type1&gt;();
container.RegisterType&lt;Type2&gt;("Instance 1", new ContainerControlledLifetimeManager());
container.RegisterType&lt;Type2&gt;("Instance 2", new ContainerControlledLifetimeManager());
container.RegisterType&lt;Type3&gt;();
Type1 type1 = container.Resolve&lt;Type1&gt;();
if (type1 == ...)
{
  Type2 instance1 = container.Resolve&lt;Type2&gt;("Instance 1");
}
else
{
  Type2 instance2 = ontainer.Resolve&lt;Type2&gt;("Instance 2");
}
