    public static UITextField TextWithIcon(this UITextField text,
                string icon, UIColor colorBorder, UIColor colorText,
                UIReturnKeyType returnkey)
    {
        text.LeftView = null; 
        var myImg = Images.LoadImageView(icon, UIViewContentMode.Center);
        myImg.Frame = new CGRect(10, 7, myImg.Frame.Width, myImg.Frame.Height);
        myImg.SizeToFit();
        var view = new UIView(new CGRect(0, 0, widthScreen, 70));
        view.AddSubview(myImg);
        text.LeftView = view;
        text.LeftViewMode = UITextFieldViewMode.Always;
        text.colorText = textColor;
        text.Layer.BorderWidth = 1f;
        text.Layer.BorderColor = colorBorder.CGColor;
        text.AttributedPlaceholder = new Foundation.NSAttributedString("placeholder", null, Colors.Black);
        text.ReturnKeyType = returnkey;
        text.SecureTextEntry = false;
        return text;
    }
