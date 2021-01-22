IUnityContainer container = new UnityContainer();
container.RegisterType&lt;TextDocument&gt;();
container.RegisterType&lt;ImageDocument&gt;();
container.RegisterType(typeof (IView), typeof (TextView), "Text", new ContainerControlledLifetimeManager());
container.RegisterType(typeof (IView), typeof (ImageView), "Image", new ContainerControlledLifetimeManager());
IDocument document = container.Resolve&lt;TextDocument&gt;();
IView view = null;
if (document is TextDocument)
{
	view = container.Resolve&lt;IView&gt;("Text");
}
else
{
	view = container.Resolve&lt;IView&gt;("Image");
}
view.Show();
