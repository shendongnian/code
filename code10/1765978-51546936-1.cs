        private bool IsAboveGroupBox(Point gbPoint, Size gbSize, Point mousePosition)
        {
            bool resultX = (mousePosition.X > gbPoint.X && mousePosition.X < gbPoint.X + gbSize.Width) ? true : false;
            bool resultY = (mousePosition.Y > gbPoint.Y && mousePosition.Y < gbPoint.Y + gbSize.Height) ? true : false;
            return resultX && resultY;
        }
