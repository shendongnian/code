    using Emgu.CV;
    using Emgu.CV.Structure;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Net;
    
    public class Program
    {
        private const string EYE_DETECTION_XML = "https://raw.githubusercontent.com/opencv/opencv/master/data/haarcascades/haarcascade_eye.xml";
        private const string SAMPLE_IMAGE = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/Lewis_Hamilton_2016_Malaysia_2.jpg/330px-Lewis_Hamilton_2016_Malaysia_2.jpg";
    
        static void Main()
        {
            // download sample photo
            WebClient client = new WebClient();
            Bitmap image = null;
            using (MemoryStream ms = new MemoryStream(client.DownloadData(SAMPLE_IMAGE)))
                image = new Bitmap(Image.FromStream(ms));
    
            // convert to Emgu image, convert to grayscale and increase brightness/contrast
            Emgu.CV.Image<Bgr, byte> emguImage = new Emgu.CV.Image<Bgr, byte>(image);
            var grayScaleImage = emguImage.Convert<Gray, byte>();
            grayScaleImage._EqualizeHist();
            
            // load eye classifier data
            string eye_classifier_local_xml = @"c:\temp\haarcascade_eye.xml";
            client.DownloadFile(@EYE_DETECTION_XML, eye_classifier_local_xml);        
            CascadeClassifier eyeClassifier = new CascadeClassifier(eye_classifier_local_xml);
    
            // perform detection which will return rectangles of eye positions
            var eyes = eyeClassifier.DetectMultiScale(grayScaleImage, 1.1, 4);
    
            // draw those rectangles on original image
            foreach (Rectangle eye in eyes)
                emguImage.Draw(eye, new Bgr(255, 0, 0), 3);
            
            // save image and show it
            string output_image_location = @"c:\temp\output.png";        
            emguImage.ToBitmap().Save(output_image_location, ImageFormat.Png);
            Process.Start(output_image_location);    
        }
    }
