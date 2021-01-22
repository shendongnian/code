    public class DebugStyleExtension : MarkupExtension
    {
        public object DebugResourceKey { get; set; }
        public object ReleaseResourceKey { get; set; }
        
        public object ProvideValue(IServiceProvider provider)
        {
    #if DEBUG
            return Application.FindResource(DebugResourceKey) as Style;
    #else
            return Application.FindResource(ReleaseResourceKey) as Style
    #endif
        }
    }
