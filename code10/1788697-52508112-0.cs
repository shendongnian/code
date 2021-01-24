            Mat padded = new Mat();                            //expand input image to optimal size
            int optimalSizeRows = Cv2.GetOptimalDFTSize(i.Rows);
            int optimalSizeCols = Cv2.GetOptimalDFTSize(i.Cols); // on the border add zero pixels
            Cv2.CopyMakeBorder(i, padded, 0, optimalSizeRows - i.Rows, 0,
                optimalSizeCols - i.Cols, BorderTypes.Constant, Scalar.All(0));
            Mat paddedFloat = new Mat();
            padded.ConvertTo(paddedFloat, MatType.CV_32FC1);
            Mat[] planes = { paddedFloat, Mat.Zeros(padded.Size(), MatType.CV_32F) };
            Mat complexI= new Mat();
            Cv2.Merge(planes, complexI);         // Add to the expanded another plane with zeros
            Mat dftImage = new Mat();
            // Apply fourier transformation
            Cv2.Dft(complexI, dftImage, DftFlags.ComplexOutput);
