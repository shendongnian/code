static MethodInfo funcSetVisibleScrollbars;
static EventHandler ehResized;
public static void DisableHorizontalScrollBar(this ScrollableControl ctrl)
{
     //cache the method info
     if(funcSetVisibleScrollbars == null)
     {
           funcSetVisibleScrollbars = typeof(ScrollableControl).GetMethod("SetVisibleScrollbars",
                BindingFlags.Instance | BindingFlags.NonPublic);
     }
     
     //init the resize event handler
     if(ehResized == null)
     {
           ehResized = (s, e) =>
           {
                funcSetVisibleScrollbars.Invoke(s, new object[] { false, (s as ScrollableControl).VerticalScroll.Visible });
           };
     }
     ctrl.Resize -= ehResized;
     ctrl.Resize += ehResized;
}
