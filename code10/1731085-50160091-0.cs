    Private Shared Sub Decaptcha(ByVal filePath As String)
        Using src = New Mat(filePath)
            Using binaryMask = New Mat()
                Dim linesColor = Scalar.FromRgb(112, 112, 112)
                Cv2.InRange(src, linesColor, linesColor, binaryMask)
                Using masked = New Mat()
                    src.CopyTo(masked, binaryMask)
                    Dim linesDilate As Integer = 3
                    Using element = Cv2.GetStructuringElement(MorphShapes.Ellipse, New Size(linesDilate, linesDilate))
                        Cv2.Dilate(masked, masked, element)
                    End Using
    
                    Cv2.CvtColor(masked, masked, ColorConversionCodes.BGR2GRAY)
                    Using dst = src.EmptyClone()
                        Cv2.Inpaint(src, masked, dst, 3, InpaintMethod.NS)
                        linesDilate = 2
                        Using element = Cv2.GetStructuringElement(MorphShapes.Ellipse, New Size(linesDilate, linesDilate))
                            Cv2.Dilate(dst, dst, element)
                        End Using
    
                        Cv2.GaussianBlur(dst, dst, New Size(5, 5), 0)
                        Using dst2 = dst.BilateralFilter(5, 75, 75)
                            Cv2.CvtColor(dst2, dst2, ColorConversionCodes.BGR2GRAY)
                            Cv2.Threshold(dst2, dst2, 255, 255, ThresholdTypes.Otsu)
                            dst2.SaveImage(Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) & "_dst" + Path.GetExtension(filePath)))
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub
