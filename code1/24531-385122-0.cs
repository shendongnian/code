[TestMethod]
public void CompareImagesSize()
{
 Image expected = Bitmap.FromFile(@"C:\ShaniData\Projects2008\TddSamples\Output\ExpectedImage.png");
 Image actual = Bitmap.FromFile(@"C:\ShaniData\Projects2008\TddSamples\Output\RhinoDiagram.png");
 Bitmap expectedBitmap = new Bitmap(expected);
 Bitmap actualBitmap = new Bitmap(actual);
 ImageAssert.HasTheSameSize(expectedBitmap, actualBitmap);
}
[TestMethod]
public void CompareTwoSameImagesButWithDifferenExtension()
{
 Image expected = Bitmap.FromFile(@"C:\ShaniData\Projects2008\TddSamples\Output\Image2.png");
 Image actual = Bitmap.FromFile(@"C:\ShaniData\Projects2008\TddSamples\Output\Image1.jpg");
 Bitmap expectedBitmap = new Bitmap(expected);
 Bitmap actualBitmap = new Bitmap(actual);
 ImageAssert.AreEqual(expectedBitmap, actualBitmap);
}
public class ImageAssert
{
    //public static void MoreMethods(Bitmap expected, Bitmap actual)
    //{
    //    //Compare image extensions
    //    //Compare Thumbnail...
    //}
 
    public static void HasTheSameSize(Bitmap expected, Bitmap actual)
    {
        if ((expected.Height != actual.Height)
            || (expected.Width != actual.Width))
            HandleFail("ImageAssert.HasTheSameSize", String.Empty);
    }
 
    public static void AreEqual(Bitmap expected, Bitmap actual)
    {
        for (int i = 0; i < expected.Width; i++)
        {
            for (int j = 0; j < expected.Height; j++)
            {
                Color expectedBit = expected.GetPixel(i, j);
                Color actualBit = actual.GetPixel(i, j);
                if (!expectedBit.Equals(actualBit))
                {
                    HandleFail("ImageAssert.AreEqual", String.Empty, i, j);
                    return;
                }
            }
        }
    }
 
    internal static void HandleFail(string assertionName, string message, params object[] parameters)
    {
        throw new AssertFailedException(String.Format(assertionName));
    }
}
  [1]: https://web.archive.org/web/20131031051646/http://human-debugger.net/wp-blog/2008/12/21/tdd-extending-assert-to-support-images/
