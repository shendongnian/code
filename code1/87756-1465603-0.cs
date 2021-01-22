    using(var dustcart = new Dustcard())
    {
       var p = dustcart.Add(new Pen(red, etc));
       var b = dustcart.Add(new Brush(black));
       Pen t;
       if (someFlag)
       {
          t = p;
       }
       else
       {
          t = dustcard.Add(new Pen(etc));
       }
    }
