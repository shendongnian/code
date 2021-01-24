    public override void WindowDidLoad()
    {
        base.WindowDidLoad();
        Window.RepresentedUrl = new NSUrl(Path.GetFullPath("check.png"));
        var btn = Window.StandardWindowButton(NSWindowButton.DocumentIconButton);
        btn.Image = NSImage.ImageNamed("check");
    }
