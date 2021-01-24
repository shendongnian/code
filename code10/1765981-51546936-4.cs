        private bool IsAboveGroupBox(GroupBox gb, Point mousePosition)
        {
            bool resultX = (mousePosition.X > gb.Location.X && mousePosition.X < gb.Location.X + gb.Size.Width) ? true : false;
            bool resultY = (mousePosition.Y > gb.Location.Y && mousePosition.Y < gb.Location.Y + gb.Size.Height) ? true : false;
            return resultX && resultY;
        }
