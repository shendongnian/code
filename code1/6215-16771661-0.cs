       void DrawDigonalString(Graphics G, string S, Font F, Brush B, PointF P, int Angle)
       {
           SizeF MySize = G.MeasureString(S, F);
           G.TranslateTransform(P.X + MySize.Width / 2, P.Y + MySize.Height / 2);
           G.RotateTransform(Angle);
           G.DrawString(S, F, B, new PointF(-MySize.Width / 2, -MySize.Height / 2));
           G.RotateTransform(-Angle);
       }
