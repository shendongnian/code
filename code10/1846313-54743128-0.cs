    CGSize oldSize;
    public ViewController (IntPtr handle) : base (handle)
    {
    }
    public override void ViewDidLoad ()
    {
        base.ViewDidLoad ();
        // Perform any additional setup after loading the view, typically from a nib.
        UITextView textView = new UITextView(new CGRect(20,20,100,30));
        oldSize = textView.Frame.Size;
        textView.Font = UIFont.SystemFontOfSize(16);
        textView.TextColor = UIColor.Black;
        textView.Changed += (sender, e) => {
          if(textView.Text.Length!=0&&textView.Text!="")
            {
                CGRect frame = textView.Frame;
                double newHeight = Math.Ceiling(textView.SizeThatFits(new CGSize(oldSize.Width,9999999999)).Height);
                // update the height if the newHeight larger than the old
                if(newHeight >= oldSize.Height)
                 {
                    textView.Frame = new CGRect(frame.X, frame.Y, frame.Size.Width, newHeight);
                 }
            }   
        };
        View.AddSubview(textView);
    }
