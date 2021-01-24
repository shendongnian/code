    public class DiagonalLines
    {
        private readonly Font font;
        private readonly Brush brush = new SolidBrush(Color.Black);
        private readonly Image image;
        private readonly float width;
        private readonly float height;
        private readonly float diagonalAngle;
        private readonly string savePath;
        public DiagonalLines(string path, string savePath)
        {
           this.image = Image.FromFile(path);
           width = image.Width;
                height = image.Height;
           //this could be optimized
           //you want to write perpendicular to the secondary diagonal, if I understood correctly
           //Math.Atan(height / width) => angle, in radians of the first diagonal
           //"-" is the angle, in radians of the secondary diagonal
           //the rest of the first term is converting radians to degrees
           diagonalAngle = -(float)(Math.Atan(height / width) * 180 / Math.PI) + /* perpendicular*/ 90;
           this.font = new Font("Arial", (float)image.Width / 80); //write about 80 characters for a full horizontal text line
           this.savePath = savePath;
    }
    public void DrawLines(params string[] lines)
    {
       using (Graphics g = Graphics.FromImage(image))
       {
           //M should be the largest character in most "western" fonts
           var lineHeight = g.MeasureString("M", font).Height;
           var halfTheLines =  (float)lines.Length / 2; //about half the lines should be "above" the midpoint of the secondary diagonal
           var offsetY = -(halfTheLines * lineHeight); //we scale the position against the line height
                                                       //same effect could probably be achieved with ScaleTransform
           g.DrawLine(Pens.Red, 0, height, width, 0); //draw the secondary diagonal
           foreach (var val in lines)
           {
                var size = g.MeasureString(val, font);
                g.ResetTransform();
                g.TranslateTransform(width / 2, height / 2); //go to center of image
                g.RotateTransform(diagonalAngle);
                //translate, to center the text and apply our offset
                g.TranslateTransform(-size.Width / 2, -size.Height / 2 + offsetY); 
                g.DrawString(val, font, brush, 0, 0);
                offsetY += lineHeight;
             }
         }
         image.Save(savePath);
    }
    }
    static void Main(string[] args)
    {
       var lines = new DiagonalLines("c:\\temp\\img\\poza.png", "c:\\temp\\img\\watermarked.jpg");
       lines.DrawLines("this", "that", "the other", "and another");
       Process.Start("c:\\temp\\img\\watermarked.jpg");
    }
