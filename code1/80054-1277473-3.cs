     using System;
     using System.Collections.Generic;
     using System.Timers;
     using System.Windows;
     using System.Windows.Media;
     using System.Windows.Media.Media3D;
     using System.Windows.Threading;
    namespace WpfApplication1
    {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Init(new Point3D(0, 0, 30), new Point3D(0,0,-30));
        }
        private Timer _timer;
        private readonly List<ModelVisual3D> _models = new List<ModelVisual3D>();
        private double _angle;
        public void Init(Point3D firstPoint, Point3D secondPoint)
        {
            var midPoint = firstPoint - secondPoint;
            var size = new Size3D(10,10,10);
            _models.Add(GetCube(GetSurfaceMaterial(Colors.Green), firstPoint, size));
            _models.Add(GetCube(GetSurfaceMaterial(Colors.Green), secondPoint, size));
            _models.Add(GetCylinder(GetSurfaceMaterial(Colors.Red), secondPoint, 2, midPoint.Z));
            
            _models.ForEach(x => mainViewport.Children.Add(x));
            _timer = new Timer(10);
            _timer.Elapsed += TimerElapsed;
            _timer.Enabled = true;
        }
        
        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<double>(Transform), 0.5d);
        }
        public MaterialGroup GetSurfaceMaterial(Color colour)
        {
            var materialGroup = new MaterialGroup();
            var emmMat = new EmissiveMaterial(new SolidColorBrush(colour));
            materialGroup.Children.Add(emmMat);
            materialGroup.Children.Add(new DiffuseMaterial(new SolidColorBrush(colour)));
            var specMat = new SpecularMaterial(new SolidColorBrush(Colors.White), 30);
            materialGroup.Children.Add(specMat);
            return materialGroup;
        }
        public ModelVisual3D GetCube(MaterialGroup materialGroup, Point3D point, Size3D size)
        {
            var farPoint = new Point3D(point.X - (size.X / 2), point.Y - (size.Y / 2), point.Z - (size.Z / 2));
            var nearPoint = new Point3D(point.X + (size.X / 2), point.Y + (size.Y / 2), point.Z + (size.Z / 2));
            var cube = new Model3DGroup();
            var p0 = new Point3D(farPoint.X, farPoint.Y, farPoint.Z);
            var p1 = new Point3D(nearPoint.X, farPoint.Y, farPoint.Z);
            var p2 = new Point3D(nearPoint.X, farPoint.Y, nearPoint.Z);
            var p3 = new Point3D(farPoint.X, farPoint.Y, nearPoint.Z);
            var p4 = new Point3D(farPoint.X, nearPoint.Y, farPoint.Z);
            var p5 = new Point3D(nearPoint.X, nearPoint.Y, farPoint.Z);
            var p6 = new Point3D(nearPoint.X, nearPoint.Y, nearPoint.Z);
            var p7 = new Point3D(farPoint.X, nearPoint.Y, nearPoint.Z);
            //front side triangles
            cube.Children.Add(CreateTriangleModel(materialGroup, p3, p2, p6));
            cube.Children.Add(CreateTriangleModel(materialGroup, p3, p6, p7));
            //right side triangles
            cube.Children.Add(CreateTriangleModel(materialGroup, p2, p1, p5));
            cube.Children.Add(CreateTriangleModel(materialGroup, p2, p5, p6));
            //back side triangles
            cube.Children.Add(CreateTriangleModel(materialGroup, p1, p0, p4));
            cube.Children.Add(CreateTriangleModel(materialGroup, p1, p4, p5));
            //left side triangles
            cube.Children.Add(CreateTriangleModel(materialGroup, p0, p3, p7));
            cube.Children.Add(CreateTriangleModel(materialGroup, p0, p7, p4));
            //top side triangles
            cube.Children.Add(CreateTriangleModel(materialGroup, p7, p6, p5));
            cube.Children.Add(CreateTriangleModel(materialGroup, p7, p5, p4));
            //bottom side triangles
            cube.Children.Add(CreateTriangleModel(materialGroup, p2, p3, p0));
            cube.Children.Add(CreateTriangleModel(materialGroup, p2, p0, p1));
            var model = new ModelVisual3D();
            model.Content = cube;
            return model;
        }
        private Model3DGroup CreateTriangleModel(MaterialGroup materialGroup, Triangle triangle)
        {
            return CreateTriangleModel(materialGroup, triangle.P0, triangle.P1, triangle.P2);
        }
        private Model3DGroup CreateTriangleModel(Material material, Point3D p0, Point3D p1, Point3D p2)
        {
            var mesh = new MeshGeometry3D();
            mesh.Positions.Add(p0);
            mesh.Positions.Add(p1);
            mesh.Positions.Add(p2);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);
            var normal = CalculateNormal(p0, p1, p2);
            mesh.Normals.Add(normal);
            mesh.Normals.Add(normal);
            mesh.Normals.Add(normal);
            var model = new GeometryModel3D(mesh, material);
            var group = new Model3DGroup();
            group.Children.Add(model);
            return group;
        }
        private Vector3D CalculateNormal(Point3D p0, Point3D p1, Point3D p2)
        {
            var v0 = new Vector3D(p1.X - p0.X, p1.Y - p0.Y, p1.Z - p0.Z);
            var v1 = new Vector3D(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);
            return Vector3D.CrossProduct(v0, v1);
        }
        void Transform(double adjustBy)
        {
            _angle += adjustBy;
            var rotateTransform3D = new RotateTransform3D {CenterX = 0, CenterZ = 0};
            var axisAngleRotation3D = new AxisAngleRotation3D {Axis = new Vector3D(1, 1, 1), Angle = _angle};
            rotateTransform3D.Rotation = axisAngleRotation3D;
            var myTransform3DGroup = new Transform3DGroup();
            myTransform3DGroup.Children.Add(rotateTransform3D);
            _models.ForEach(x => x.Transform = myTransform3DGroup);
        }
        public ModelVisual3D GetCylinder(MaterialGroup materialGroup, Point3D midPoint, double radius, double depth)
        {
            var cylinder = new Model3DGroup();
            var nearCircle = new CircleAssitor();
            var farCircle = new CircleAssitor();
            var twoPi = Math.PI * 2;
            var firstPass = true;
            double x;
            double y;
            var increment = 0.1d;
            for (double i = 0; i < twoPi + increment; i = i + increment)
            {
                x = (radius * Math.Cos(i));
                y = (-radius * Math.Sin(i));
                farCircle.CurrentTriangle.P0 = midPoint;
                farCircle.CurrentTriangle.P1 = farCircle.LastPoint;
                farCircle.CurrentTriangle.P2 = new Point3D(x + midPoint.X, y + midPoint.Y, midPoint.Z);
                nearCircle.CurrentTriangle = farCircle.CurrentTriangle.Clone(depth, true);
                if (!firstPass)
                {
                    cylinder.Children.Add(CreateTriangleModel(materialGroup, farCircle.CurrentTriangle));
                    cylinder.Children.Add(CreateTriangleModel(materialGroup, nearCircle.CurrentTriangle));
                    cylinder.Children.Add(CreateTriangleModel(materialGroup, farCircle.CurrentTriangle.P2, farCircle.CurrentTriangle.P1, nearCircle.CurrentTriangle.P2));
                    cylinder.Children.Add(CreateTriangleModel(materialGroup, nearCircle.CurrentTriangle.P2, nearCircle.CurrentTriangle.P1, farCircle.CurrentTriangle.P2));
                }
                else
                {
                    farCircle.FirstPoint = farCircle.CurrentTriangle.P1;
                    nearCircle.FirstPoint = nearCircle.CurrentTriangle.P1;
                    firstPass = false;
                }
                farCircle.LastPoint = farCircle.CurrentTriangle.P2;
                nearCircle.LastPoint = nearCircle.CurrentTriangle.P2;
            }
            var model = new ModelVisual3D {Content = cylinder};
            return model;
        }
    }
    public class CircleAssitor
    {
        public CircleAssitor()
        {
            CurrentTriangle = new Triangle();
        }
        public Point3D FirstPoint { get; set; }
        public Point3D LastPoint { get; set; }
        public Triangle CurrentTriangle { get; set; }
    }
    public class Triangle
    {
        public Point3D P0 { get; set; }
        public Point3D P1 { get; set; }
        public Point3D P2 { get; set; }
        public Triangle Clone(double z, bool switchP1andP2)
        {
            var newTriangle = new Triangle();
            newTriangle.P0 = GetPointAdjustedBy(this.P0, new Point3D(0, 0, z));
            var point1 = GetPointAdjustedBy(this.P1, new Point3D(0, 0, z));
            var point2 = GetPointAdjustedBy(this.P2, new Point3D(0, 0, z));
            if (!switchP1andP2)
            {
                newTriangle.P1 = point1;
                newTriangle.P2 = point2;
            }
            else
            {
                newTriangle.P1 = point2;
                newTriangle.P2 = point1;
            }
            return newTriangle;
        }
        private Point3D GetPointAdjustedBy(Point3D point, Point3D adjustBy)
        {
            var newPoint = new Point3D { X = point.X, Y = point.Y, Z = point.Z };
            newPoint.Offset(adjustBy.X, adjustBy.Y, adjustBy.Z);
            return newPoint;
        }
    }
    }
