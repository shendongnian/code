            double longestHorLine = 201;
            Image<Gray, byte> toErode = new Image<Gray, byte>(path+ "toErode.png");
            for(int i =1;i<4;i++)
            {
                Mat element = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size((int)(longestHorLine / i), 3), new Point(-1, -1));
                CvInvoke.Erode(toErode, toErode, element, new Point(-1, -1), i, BorderType.Default, new MCvScalar(0));
                toErode.Save(path + "res"+i+".png");
            }
