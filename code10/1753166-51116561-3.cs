     public override void LayoutSubviews()
            {
                base.LayoutSubviews();
                Control.Layer.Sublayers[sublayerNumber].MasksToBounds = true;
                Control.Layer.Sublayers[sublayerNumber].Frame = new CoreGraphics.CGRect(0f, Frame.Height - 5, Frame.Width, 1f);
                Control.Layer.Sublayers[sublayerNumber].BorderColor = Color.FromHex("YOUR-HEX-CODE-HERE").ToCGColor();
                Control.Layer.Sublayers[sublayerNumber].BorderWidth = 1.0f;
            }
