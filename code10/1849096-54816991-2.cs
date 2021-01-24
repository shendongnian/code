    public override void ViewWillAppear(bool animated)
    {
        base.ViewWillAppear(animated);
        this.titleLabel.Text = Title;
        this.messageLabel.Text = Message;
        //If you don't set an image while Create, it will use the default image you set on the Designer.
        if (Image != null)
        {
            this.imageView.Image = Image;
        }
    }    
