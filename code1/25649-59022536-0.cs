	using System;
	using System.Reflection;
	using System.Windows;
	using System.Windows.Markup;
    namespace MyNamespace
    {
		[UsableDuringInitialization(true), Ambient, DefaultMember("Item")]
		public class ComponentResources : ResourceDictionary
		{
			static ResourceDictionary _inst;
			public ComponentResources()
			{
				if (_inst == null)
				{
					var uri = new Uri("/my-class-lib;component/resources.xaml", UriKind.Relative);
					_inst = (ResourceDictionary)Application.LoadComponent(uri);
				}
				base.MergedDictionaries.Add(_inst);
			}
		};
    }
