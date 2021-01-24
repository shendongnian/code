            var newImage = magickImage.Clone();
            var stats = newImage.Statistics().GetChannel(PixelChannel.Composite);
            var mean = stats.Mean / (stats.Maximum - stats.Minimum);
            var stDev = stats.StandardDeviation / (stats.Maximum - stats.Minimum);
            var whiteThreshold = new Percentage(100 - (mean + 0.5 * stDev));
            var blackThreshold = new Percentage(mean - 0.5 * stDev);
            
            newImage.ColorFuzz = new Percentage(3);
            newImage.WhiteThreshold(whiteThreshold);
            newImage.BlackThreshold(blackThreshold);
            newImage.Opaque(MagickColors.Black, MagickColors.Green);
            newImage.Opaque(MagickColors.White, MagickColors.Black);
            newImage.InverseOpaque(MagickColors.Black, MagickColors.White);
            magickImage.WriteMask = newImage;
