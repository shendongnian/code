    /// <summary>
    /// Example Image Processing class
    /// Demonstrates treating images as 2D arrays.
    /// </summary>
    public class ImageProcessor {
        /// <summary>
        /// Creates a 2D array of Colors from a bitmap.
        /// </summary>
        /// <param name="bm">The input bitmap</param>
        /// <returns>The output Color array</returns>
        public static Color[,] BitmapToColorArray(Bitmap bm) {
            int width = bm.Width;
            int height = bm.Height;
            Color[,] colorArray = new Color[width, height];
            for (int y = 0; y < height; ++y) {
                for (int x = 0; x < width; ++x) {
                    colorArray[x, y] = bm.GetPixel(x, y);
                }
            }
            return colorArray;
        }
        /// <summary>
        /// Creates a Bitmap from a 2D array of Colors.
        /// </summary>
        /// <param name="colorArray">The input Color 2D array</param>
        /// <returns>The output bitmap</returns>
        public static Bitmap ColorArrayToBitmap(Color[,] colorArray) {
            int width = colorArray.GetLength(0);
            int height = colorArray.GetLength(1);
            Bitmap bm = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            for (int y = 0; y < height; ++y) {
                for (int x = 0; x < width; ++x) {
                    bm.SetPixel(x, y, colorArray[x, y]);
                }
            }
            return bm;
        }
        /// <summary>
        /// Converts a Color to a gray value 0-255.
        /// </summary>
        /// <param name="color">The input color</param>
        /// <returns>The output gray value.</returns>
        public static int ColorToGray(Color color) {
            int gray = (color.R * 30 + color.G * 59 + color.B * 11) / 100;
            return gray;
        }
        /// <summary>
        /// Converts a gray value to a Color
        /// </summary>
        /// <param name="gray">The input gray value</param>
        /// <returns>The output Color</returns>
        public static Color GrayToColor(int gray) {
            return Color.FromArgb(gray, gray, gray);
        }
        /// <summary>
        /// Creates a 2D gray array from a 2D Color array
        /// </summary>
        /// <param name="colorArray">The input 2D Color array</param>
        /// <returns>The output 2D gray array</returns>
        public static int[,] ColorArrayToGrayArray(Color[,] colorArray) {
            int width = colorArray.GetLength(0);
            int height = colorArray.GetLength(1);
            int[,] grayArray = new int[width, height];
            for (int y = 0; y < height; ++y) {
                for (int x = 0; x < width; ++x) {
                    grayArray[x,y] = ColorToGray(colorArray[x, y]);
                }
            }
            return grayArray;
        }
        /// <summary>
        /// Creates a 2D Color Array from a 2D gray array
        /// </summary>
        /// <param name="grayArray">The input 2D gray array</param>
        /// <returns>The output 2D Color array</returns>
        public static Color[,] GrayArrayToColorArray(int[,] grayArray) {
            int width = grayArray.GetLength(0);
            int height = grayArray.GetLength(1);
            Color[,] colorArray = new Color[width, height];
            for (int y = 0; y < height; ++y) {
                for (int x = 0; x < width; ++x) {
                    colorArray[x, y] = GrayToColor(grayArray[x, y]);
                }
            }
            return colorArray;
        }
        /// <summary>
        /// Generic function to extract a 2D rectangular sub-area of an array as a new 2D array.
        /// </summary>
        /// <typeparam name="T">The generic type</typeparam>
        /// <param name="src">The input 2D array</param>
        /// <param name="srcx">The column of the top-left corner of the sub-area to extract</param>
        /// <param name="srcy">The row of the top-left corner of the sub-area to extract</param>
        /// <param name="dstWidth">The width of the sub-area to extract</param>
        /// <param name="dstHeight">The height o fthe sub-area to extract</param>
        /// <returns>The output 2D array</returns>
        public static T[,] SubArray<T>(T[,] src, int srcx, int srcy, int dstWidth, int dstHeight) {
            int srcWidth = src.GetLength(0);
            int srcHeight = src.GetLength(1);
            if (srcx < 0) throw new ArgumentOutOfRangeException();
            if (srcy < 0) throw new ArgumentOutOfRangeException();
            if (srcx + dstWidth > srcWidth) throw new ArgumentOutOfRangeException();
            if (srcy + dstHeight > srcHeight) throw new ArgumentOutOfRangeException();
            T[,] dst = new T[dstWidth, dstHeight];
            for (int dsty = 0; dsty < dstHeight; ++dsty) {
                for (int dstx = 0; dstx < dstWidth; ++dstx) {
                    dst[dstx, dsty] = src[srcx + dstx, srcy + dsty];
                }
            }
            return dst;
        }
        /// <summary>
        /// Generic function to convert a 2D array into blocks (2D array of 2D arrays)
        /// </summary>
        /// <typeparam name="T">The generic type</typeparam>
        /// <param name="src">The input 2D array</param>
        /// <param name="blockSize">The width and height of each square block</param>
        /// <returns>The output 2D array of 2D arrays</returns>
        public T[,][,] ArrayToBlockArray<T>(T[,] src, int blockSize) {
            int srcWidth = src.GetLength(0);
            int srcHeight = src.GetLength(1);
            if (srcWidth % blockSize != 0) throw new Exception(string.Format("Width must be divisible by {0}", blockSize));
            if (srcHeight % blockSize != 0) throw new Exception(string.Format("Height must be divisible by {0}", blockSize));
            int dstWidth = srcWidth / blockSize;
            int dstHeight = srcHeight / blockSize;
            T[,][,] dst = new T[dstWidth, dstHeight][,]; // The syntax for creating new array of arrays is weird.
            for (int dsty = 0; dsty < dstHeight; ++dsty) {
                for (int dstx = 0; dstx < dstWidth; ++dstx) {
                    dst[dstx, dsty] = SubArray(src, dstx * blockSize, dsty * blockSize, blockSize, blockSize);
                }
            }
            return dst;
        }
        /// <summary>
        /// Generic function to convert a 2D array of blocks (2D array of 2D arrays) back into a single 2D array.
        /// </summary>
        /// <typeparam name="T">The generic type</typeparam>
        /// <param name="src">The input 2D array of 2D arrays</param>
        /// <returns>The output 2D array</returns>
        public T[,] BlockArrayToArray<T>(T[,][,] src) {
            // assume uniform size
            int blockWidth = src[0, 0].GetLength(0);
            int blockHeight = src[0, 0].GetLength(1);
            int srcWidth = src.GetLength(0);
            int srcHeight = src.GetLength(1);
            int dstWidth = srcWidth * blockWidth;
            int dstHeight = srcHeight * blockHeight;
            T[,] dst = new T[dstWidth, dstHeight];
            for (int srcy = 0; srcy < srcHeight; ++srcy) {
                for (int srcx = 0; srcx < srcWidth; ++srcx) {
                    for (int blocky = 0; blocky < blockHeight; ++blocky ) {
                        for (int blockx = 0; blockx < blockWidth; ++blockx) {
                            T[,] block = src[srcx, srcy];
                            if (block.GetLength(0) != blockWidth) throw new Exception(string.Format("Blocks must all have width {0}", blockWidth));
                            if (block.GetLength(1) != blockHeight) throw new Exception(string.Format("Blocks must all have height {0}", blockHeight));
                            int dstx = srcx * blockWidth + blockx;
                            int dsty = srcy * blockHeight + blocky;
                            dst[dstx, dsty] = src[srcx, srcy][blockx, blocky];
                        }
                    }
                }
            }
            return dst;
        }
        /// <summary>
        /// Example function that does end-to-end processing of a Bitmap.
        /// </summary>
        /// <param name="srcBitmap">The input bitmap</param>
        /// <returns>The output bitmap</returns>
        public Bitmap Process(Bitmap srcBitmap) {
            const int blockSize = 4;
            Color[,] srcColorArray = BitmapToColorArray(srcBitmap);
            int[,] srcGrayArray = ColorArrayToGrayArray(srcColorArray);
            int[,][,] srcBlockArray = ArrayToBlockArray(srcGrayArray, blockSize);
            // TODO: Presumably you're going to modify the source block array.
            int[,][,] dstBlockArray = srcBlockArray; // PLACEHOLDER: do nothing for now.
            // Reconstitute a new bitmap from the (presumably modified) destination block array.
            int[,] dstGrayArray = BlockArrayToArray(dstBlockArray);
            Color[,] dstColorArray = GrayArrayToColorArray(dstGrayArray);
            Bitmap dstBitmap = ColorArrayToBitmap(dstColorArray);
            return dstBitmap;
        }
    }
