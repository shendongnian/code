    using System.Windows;
    using System.Windows.Controls;
    using System.Threading;
    using System;
    using System.Windows.Input;
    
    namespace TestFocksdfj
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                StackPanel sp = new StackPanel();
    
                for (int i = 0; i < 3; i++)
                {
                    TextBox tb = new TextBox();
                    tb.Width = 200;
                    tb.Margin = new Thickness { Bottom = 3 };
                    if (i == 2)
                    {
                        FocusHelper.Focus(tb);
                    }
                    sp.Children.Add(tb);
                }
    
                FormArea.Content = sp;
            }
        }
    
        //thanks to: http://apocryph.org/2006/09/10/wtf_is_wrong_with_wpf_focus/
        static class FocusHelper
        {
            private delegate void MethodInvoker();
    
            public static void Focus(UIElement element)
            {
                ThreadPool.QueueUserWorkItem(delegate(Object foo)
                {
                    UIElement elem = (UIElement)foo;
                    elem.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                        (MethodInvoker)delegate()
                        {
                            elem.Focus();
                            Keyboard.Focus(elem);
                        });
                }, element);
            }
        }
    
    }
