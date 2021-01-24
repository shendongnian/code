    public Image<Bgr, Byte> GetFacePoints()
        {
            CascadeClassifier faceDetector = new CascadeClassifier(@"..\..\Resource\EMGUCV\haarcascade_frontalface_default.xml");
            FacemarkLBFParams fParams = new FacemarkLBFParams();
            fParams.ModelFile = @"..\..\Resource\EMGUCV\lbfmodel.yaml";
            fParams.NLandmarks = 68; // number of landmark points
            fParams.InitShapeN = 10; // number of multiplier for make data augmentation
            fParams.StagesN = 5; // amount of refinement stages
            fParams.TreeN = 6; // number of tree in the model for each landmark point
            fParams.TreeDepth = 5; //he depth of decision tree
            FacemarkLBF facemark = new FacemarkLBF(fParams);
            //facemark.SetFaceDetector(MyDetector);
            Image<Bgr, Byte> image = new Image<Bgr, byte>(@"C:\Users\matias\Downloads\personas-buena-vibra-caracteristicas-1200x600.jpg");
            Image<Gray, byte> grayImage = image.Convert<Gray, byte>();
            grayImage._EqualizeHist();
            VectorOfRect faces = new VectorOfRect(faceDetector.DetectMultiScale(grayImage));
            VectorOfVectorOfPointF landmarks = new VectorOfVectorOfPointF();
            facemark.LoadModel(fParams.ModelFile);
            bool success = facemark.Fit(grayImage, faces, landmarks);
            if (success)
            {
                Rectangle[] facesRect = faces.ToArray();
                for (int i = 0; i < facesRect.Length; i++)
                {
                    image.Draw(facesRect[i], new Bgr(Color.Blue), 2);
                    FaceInvoke.DrawFacemarks(image, landmarks[i], new Bgr(Color.Blue).MCvScalar);
                }
                return image;
            }
            return null;
        }
