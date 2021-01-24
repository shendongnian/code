            viewBlack = new UIView();
            viewBlack.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);
            viewBlack.BackgroundColor = UIColor.Black;
            viewBlack.Alpha = 0.5f;
            viewBlack.Hidden = true;
            this.View.AddSubviews(viewBlack);
