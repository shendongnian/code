    using System;
    using System.Windows;
    using System.Windows.Interactivity;
    namespace NaiveMepUi.GuiCommon
    {
    public class RoutedEventTrigger : EventTriggerBase<DependencyObject>
    {
        public RoutedEventTrigger() { }
    
        public RoutedEvent RoutedEvent { get; set; }
    
        protected override void OnAttached()
        {
            Behavior behavior = base.AssociatedObject as Behavior;
            FrameworkElement associatedElement =
                base.AssociatedObject as FrameworkElement;
    
            if (behavior != null)
            {
                associatedElement =
                    ((IAttachedObject)behavior).AssociatedObject as FrameworkElement;
            }
            if (associatedElement == null)
            {
                throw new ArgumentException
                    ("RoutedEventTrigger.AssociatedObject is not FrameworkElement.");
            }
            if (RoutedEvent != null)
            {
                associatedElement.AddHandler(
                    RoutedEvent,
                    new RoutedEventHandler(this.OnRoutedEvent));
            }
        }
    
        /// <summary>
        /// 路由事件被引发，继而引发基类的事件回调；
        /// 但是这一步会丢弃<paramref name="sender"/>。
        /// 如果事件绑定到命令，则命令只能接收到<paramref name="args"/>；
        /// 作为在 ViewModel 中定义的命令，原则上不应该 View 中定义的元素。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnRoutedEvent(object sender, RoutedEventArgs args)
        {
            base.OnEvent(args);
        }
    
        protected override string GetEventName()
        {
            return RoutedEvent.Name;
        }
    }
    }
