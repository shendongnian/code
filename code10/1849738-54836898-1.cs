[DllImport (Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
public extern static IntPtr IntPtr_objc_msgSend (IntPtr receiver, IntPtr selector);
public static UIImage GetImage (UIBarButtonSystemItem systemItem)
{
    var tempItem = new UIBarButtonItem (systemItem);
    // Add to toolbar and render it
    var bar = new UIToolbar ();
    bar.SetItems (new [] { tempItem }, false);
    bar.SnapshotView (true);
    // Get image from real UIButton
    var selHandle = Selector.GetHandle ("view");
    var itemView = Runtime.GetNSObject<UIView>(IntPtr_objc_msgSend (tempItem.Handle, selHandle));
    foreach    (var view in itemView?.Subviews) {
        if (view is UIButton button)
            return button.ImageForState (UIControlState.Normal);
    }
    return null;
}
Solution provided by @DaleXSoto from the Xamarin iOS Gitter
"The thing is that you are calling a selector (view) into the tempItem object
but it is a hack since a UIBarButtonItem responds to view just because someone figured that out heh, it is not on the headers
So doing IntPtr_objc_msgSend is how you are calling view on tempItem object"
