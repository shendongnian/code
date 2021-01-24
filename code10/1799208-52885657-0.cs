    UIView.Animate(0.8, () =>
      {
        CGRect outRect= new CGRect(0, menuView.Frame.Y, menuView.Frame.Width, menuView.Frame.Height);
        menuView.Frame = pushRect;
      });
