    namespace XamarinStart.Extensions
    {
        public static class PageAwareExtension
        {
            public static void AttachLifecycleToPage(this Element element, EventHandler onAppearing = null,
                EventHandler onDisappearing = null)
            {
                var task = new Task(() =>
                {
                    var page = GetPage(element);
                    if (page == null)
                    {
                        return;
                    }
    
                    if (onAppearing != null)
                    {
                        page.Appearing += onAppearing;
                    }
    
                    if (onDisappearing != null)
                    {
                        page.Disappearing += onDisappearing;
                    }
                });
                task.Start();
                return;
            }
            public static Page GetPage(this Element element, int timeout = -1)
            {
                if (element is Page) return (Page)element;
    
                Element el = element;
                // go up along the UI tree
                do
                {
                    if (el.Parent == null)
                    {
                        // either not attached to any parent, or no intend to attach to any page (is that possible?)
                        var signal = new AutoResetEvent(false);
                        PropertyChangedEventHandler handler = (object sender, PropertyChangedEventArgs args) =>
                        {
                            // https://github.com/xamarin/Xamarin.Forms/blob/master/Xamarin.Forms.Core/Element.cs
                            // Setting Parent property is tracked
                            Element senderElement = (Element) sender;
                            if (args.PropertyName == "Parent" && senderElement.Parent != null)
                            {
                                signal.Set();
                            }
                        };
                        el.PropertyChanged += handler;
    
                        var gotSignal = signal.WaitOne(timeout);
                        if (!gotSignal)
                        {
                            throw new TimeoutException("Cannot find the parent of the element");
                        }
    
                        el.PropertyChanged -= handler;
                    } // if parent is null
    
                    el = el.Parent;
    
                } while (! (el is Page));
    
                return (Page) el;
            }
        }
    }
