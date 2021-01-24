    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap bmp = Bitmap.FromFile("lenagr.png") as Bitmap;
            pictureBox1.Image = bmp;
            Complex[,] cImage = ToComplex(bmp);
            for (int y = 0; y < cImage.GetLength(1); y++)
            {
                for (int x = 0; x < cImage.GetLength(0); x++)
                {
                    if (((x + y) & 0x1) != 0)
                    {
                        double real = cImage[y, x].Real * (-1);
                        double imaginary = cImage[y, x].Imaginary * (-1);
                        cImage[y, x] = new Complex(real, imaginary);
                    }
                }
            }
            FourierTransform.FFT2(cImage, FourierTransform.Direction.Forward);
            double[,] intImage = ToDouble(cImage);
            intImage = Limit(intImage);
            Bitmap bmpMagImg = ToBitmap(intImage, PixelFormat.Format24bppRgb);
            pictureBox2.Image = bmpMagImg;
        }
        public static double[,] Limit(double[,] image)
        {
            double[,] imageCopy = (double[,])image.Clone();
            double min = 0;
            double max = 1;
            int Width = imageCopy.GetLength(0);
            int Height = imageCopy.GetLength(1);
            double[,] array2d = new double[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    array2d[i, j] = Math.Max(min, Math.Min(imageCopy[i, j], max));
                }
            }
            return array2d;
        }
        public double[,] ToDouble(Complex[,] image)
        {
            int Width = image.GetLength(0);
            int Height = image.GetLength(1);
            double[,] array2d = new double[Width, Height];
            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    array2d[i, j] = (double)image[i, j].Magnitude;
                }
            }
            return array2d;
        }
        public Bitmap ToBitmap(double[,] image, PixelFormat pixelFormat)
        {
            double[,] imageCopy = (double[,])image.Clone();
            // Image is Grayscale
            // Each element is scaled to (0-255) range.
            int Width = imageCopy.GetLength(0);
            int Height = imageCopy.GetLength(1);
            Bitmap bitmap = new Bitmap(Width, Height, pixelFormat);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    // In case of a grayscale image, 
                    // each pixel has same R,G, and B values.
                    double d = imageCopy[x, y];
                    int iii = Convert.ToInt32(d * 255.0);
                    Color clr = Color.FromArgb(iii, iii, iii);
                    bitmap.SetPixel(x, y, clr);
                }
            }
            Grayscale.SetPalette(bitmap);
            return bitmap;
        }
        
        public Complex[,] ToComplex(Bitmap image)
        {
            if (!Grayscale.IsGrayscale(image))
            {
                throw new Exception("Source image must not be color");
            }
            int[,] array2d = ToInteger(image);
            return ToComplex(array2d);
        }
        
        public int[,] ToInteger(Bitmap input)
        {
            if (!Grayscale.IsGrayscale(input))
            {
                throw new Exception("Source image must not be color");
            }
            int Width = input.Width;
            int Height = input.Height;
            int[,] array2d = new int[Width, Height];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Color cl = input.GetPixel(x, y);
                    int gray = (int)Convert.ChangeType(cl.R * 0.3 + cl.G * 0.59 + cl.B * 0.11, typeof(int));
                    array2d[x, y] = gray;
                }
            }
            return array2d;
        }
        public Complex[,] ToComplex(int[,] image)
        {
            int Width = image.GetLength(0);
            int Height = image.GetLength(1);
            Complex[,] array2d = new Complex[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    double d = (double)image[i, j];
                    Complex tempComp = new Complex(d, 0.0);
                    array2d[i, j] = tempComp;
                }
            }
            return array2d;
        }
    }
