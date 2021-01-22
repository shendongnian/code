    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    /// <summary>
    /// Applies a pixelation effect to an image.
    /// </summary>
    [SuppressMessage(
        "Microsoft.Naming",
        "CA1704",
        Justification = "'Pixelate' is a word in my book.")]
    public class PixelateEffect : EffectBase
    {
        /// <summary>
        /// Gets or sets the block size, in pixels.
        /// </summary>
        private int blockSize = 10;
        /// <summary>
        /// Gets or sets the block size, in pixels.
        /// </summary>
        public int BlockSize
        {
            get
            {
                return this.blockSize;
            }
            set
            {
                if (value <= 1)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                this.blockSize = value;
            }
        }
        /// <summary>
        /// Applies the effect by rendering it onto the target bitmap.
        /// </summary>
        /// <param name="source">The source bitmap.</param>
        /// <param name="target">The target bitmap.</param>
        public override void DrawImage(Bitmap source, Bitmap target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }
            if (source.Size != target.Size)
            {
                throw new ArgumentException("The source bitmap and the target bitmap must be the same size.");
            }
            using (var graphics = Graphics.FromImage(target))
            {
                graphics.PageUnit = GraphicsUnit.Pixel;
                for (int x = 0; x < source.Width; x += this.BlockSize)
                {
                    for (int y = 0; y < source.Height; y += this.BlockSize)
                    {
                        var sums = new Sums();
                        for (int xx = 0; xx < this.BlockSize; ++xx)
                        {
                            for (int yy = 0; yy < this.BlockSize; ++yy)
                            {
                                if (x + xx >= source.Width || y + yy >= source.Height)
                                {
                                    continue;
                                }
                                var color = source.GetPixel(x + xx, y + yy);
                                sums.A += color.A;
                                sums.R += color.R;
                                sums.G += color.G;
                                sums.B += color.B;
                                sums.T++;
                            }
                        }
                        var average = Color.FromArgb(
                            sums.A / sums.T,
                            sums.R / sums.T,
                            sums.G / sums.T,
                            sums.B / sums.T);
                        using (var brush = new SolidBrush(average))
                        {
                            graphics.FillRectangle(brush, x, y, (x + this.BlockSize), (y + this.BlockSize));
                        }
                    }
                }
            }
        }
        /// <summary>
        /// A structure that holds sums for color averaging.
        /// </summary>
        private struct Sums
        {
            /// <summary>
            /// Gets or sets the alpha component.
            /// </summary>
            public int A
            {
                get;
                set;
            }
            /// <summary>
            /// Gets or sets the red component.
            /// </summary>
            public int R
            {
                get;
                set;
            }
            /// <summary>
            /// Gets or sets the blue component.
            /// </summary>
            public int B
            {
                get;
                set;
            }
            /// <summary>
            /// Gets or sets the green component.
            /// </summary>
            public int G
            {
                get;
                set;
            }
            /// <summary>
            /// Gets or sets the total count.
            /// </summary>
            public int T
            {
                get;
                set;
            }
        }
    }
