        class TabControlBehavior : Behavior<TabControl>
    {
        public static readonly DependencyProperty PluginsProperty =
           DependencyProperty.RegisterAttached("Plugins", typeof(IEnumerable<PluginVM>), typeof(TabControlBehavior));
        public IEnumerable<PluginVM> Plugins
        {
            get { return (IEnumerable<PluginVM>)GetValue(PluginsProperty); }
            set { SetValue(PluginsProperty, value); }
        }
        protected override void OnAttached()
        {
            TabControl tabctrl = this.AssociatedObject;
            foreach (PluginVM item in Plugins)
            {
                if (item.IsEnabled)
                {
                    
					byte[] icon = item.Plugin.Icon();
					BitmapImage image = new BitmapImage();
					if (icon != null && icon.Length > 0)
					{
						image = (BitmapImage)new Yemp.Converter.DataToImageConverter().Convert(icon, typeof(BitmapImage), null, CultureInfo.CurrentCulture);
					}
					Image imageControl = new Image();
					imageControl.Source = image;
					imageControl.Width = 32;
					imageControl.Height = 32;
					TabItem t = new TabItem();
					
					t.Header = imageControl;
					t.Content = item.Plugin.View;
					tabctrl.Items.Add(t);
                    
                }                           
            }
        }
        protected override void OnDetaching()
        {
        }
    }
