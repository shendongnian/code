    public partial class BlinkingLightControl : UserControl
    {
        public static readonly RoutedEvent FlashGreenEvent = EventManager.RegisterRoutedEvent("FlashGreen", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(BlinkingLightControl));
        public event RoutedEventHandler FlashGreen
        {
            add { AddHandler(FlashGreenEvent, value); }
            remove { RemoveHandler(FlashGreenEvent, value); }
        }
        private void BlinkingLightControl_Loaded(object sender, RoutedEventArgs e)
        {
            BlinkingLight rblinkingLight = (BlinkingLight)this.DataContext;
            blinkingLight.Led.Flash += LED_Flash;
        }
        protected delegate void LED_FlashCallback(ThirdParty.LED sender);
        public void LED_Flash(ThirdParty.LED sender)
        {
            if (this.Dispatcher.CheckAccess())
            {
                // Raise the Flash Green Event;
                RaiseEvent(new RoutedEventArgs(BlinkingLightControl.FlashGreenEvent));
            }
            else
                this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new LED_FlashCallback(LED_Flash), sender);
        }
    }
