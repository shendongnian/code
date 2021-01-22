    namespace Something
    {
        public class Highlighter
        {
            ScreenBoundingRectangle _rectangle = new ScreenBoundingRectangle();
            public void DrawRectangle(Rectangle rect)
            {
                _rectangle.Color = System.Drawing.Color.Red;
                _rectangle.Opacity = 0.8;
                _rectangle.Location = rect;
                this._rectangle.Visible = true;
            }
        }
    }
