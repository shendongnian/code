    public class DebugStyleExtension : MarkupExtension
    {
        public object DebugResourceKey { get; set; }
        public object ReleaseResourceKey { get; set; }
        
        public object ProvideValue(IServiceProvider provider)
        {
    #if DEBUG
            return Application.Current.FindResource(DebugResourceKey) as Style;
    #else
            return Application.Current.FindResource(ReleaseResourceKey) as Style
    #endif
        }
    }
