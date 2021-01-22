        private void MouseMove(object sender, MouseEventArgs e)
        {
            Point punto = e.GetPosition(canvas);
            int mouseX = (int)punto.X;
            int mouseY = (int)punto.Y;
            bola.SetValue(Canvas.LeftProperty, (double)mouseX); //set x
            bola.SetValue(Canvas.LeftProperty, (double)mouseY); //set y
           
        }
