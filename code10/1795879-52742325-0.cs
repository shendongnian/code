            var i = Image.FromFile("pic.png");
            List<IntPoint> corners = new List<IntPoint>();
            corners.Add(new IntPoint(63, 183));
            corners.Add(new IntPoint(863, 151));
            corners.Add(new IntPoint(869, 182));
            corners.Add(new IntPoint(65, 211));
            QuadrilateralTransformation filter = new QuadrilateralTransformation(corners, 869 - 63, 211 - 183);
            var i2 = filter.Apply(i);
            i2.Save("pic2.png");
