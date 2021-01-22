        int movX;
        int moxY;
        bool isMoving;
        
        private void onMouseDown(object sender, MouseEventArgs e)  
        {
             // Assign this method to mouse_Down event of Form or Panel,whatever you want
            isMoving = true;
            movX = e.X;
            movY = e.Y;
        }
        private void onMouseMove(object sender, MouseEventArgs e)
        {
             // Assign this method to Mouse_Move event of that Form or Panel
            if (isMoving)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }
        private void onMouseUp(object sender, MouseEventArgs e)
        {
           // Assign this method to Mouse_Up event of Form or Panel.
            isMoving = false;
        }
