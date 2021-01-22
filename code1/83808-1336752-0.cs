    foreach (Led l in MinuteGrid.Leds)
    {
         if (l.IsLit)
         {
             using(LinearGradientBrush b = new LinearGradientBrush(l.LedRectangle, Color.GreenYellow, Color.Green, 110))
             {
                g.FillRectangle(b, l.LedRectangle);
             }
         }
    }
