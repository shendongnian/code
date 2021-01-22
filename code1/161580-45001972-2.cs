    public class MyCanvas : Canvas {
        public int CanvasId { get; private set; }
        private double canvasHeight; // member vars consist of 2+ words
        private double canvasWidth;
        public MyCanvas(int id) {
            CanvasId = id;
            double height = ...; // local vars consist of one word/letter
            canvasHeight = height;
        }
    }
