    public partial class Window1 : Window {
        const float ANGLE = 30;
        const float WIDTH = 8;
        public Window1() {
            InitializeComponent();
            var group = new Model3DGroup();
            group.Children.Add(Create3DImage(@"C:\Users\fak\Pictures\so2.png"));
            group.Children.Add(new AmbientLight(Colors.White));
            ModelVisual3D visual = new ModelVisual3D();
            visual.Content = group;
            viewport.Children.Add(visual);
        }
        private GeometryModel3D Create3DImage(string imgFilename) {
            var image = LoadImage(imgFilename);
            var mesh = new MeshGeometry3D();
            var height = (WIDTH * image.PixelHeight) / image.PixelWidth;
            var w2 = WIDTH / 2.0;
            var h2 = height / 2.0;
            mesh.Positions.Add(new Point3D(-w2, -h2, 0));
            mesh.Positions.Add(new Point3D(w2, -h2, 0));
            mesh.Positions.Add(new Point3D(w2, h2, 0));
            mesh.Positions.Add(new Point3D(-w2, h2, 0));
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(3);
            mesh.TextureCoordinates.Add(new Point(0, 1)); // 0, 0
            mesh.TextureCoordinates.Add(new Point(1, 1));
            mesh.TextureCoordinates.Add(new Point(1, 0));
            mesh.TextureCoordinates.Add(new Point(0, 0));
            var mat = new DiffuseMaterial(new ImageBrush(image));
            mat.AmbientColor = Colors.White;
            var geometry = new GeometryModel3D();
            geometry.Geometry = mesh;
            geometry.Material = mat;
            geometry.BackMaterial = mat;
            geometry.Transform = new RotateTransform3D(
                new AxisAngleRotation3D(new Vector3D(0,1,0), ANGLE),
                new Point3D(0, 0, 0));
            return geometry;
        }
        public static BitmapSource LoadImage(string filename) {
            return BitmapDecoder.Create(new Uri(filename, UriKind.RelativeOrAbsolute),
                BitmapCreateOptions.None, BitmapCacheOption.Default).Frames[0];
        }
    }
