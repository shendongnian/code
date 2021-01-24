    public partial class MainWindow : Window
    {
        Viewport3D myViewport3D = new Viewport3D();
        Model3DGroup myModel3DGroup = new Model3DGroup();
        ModelVisual3D myModelVisual3D = new ModelVisual3D();
        PerspectiveCamera myPCamera = new PerspectiveCamera();
        ...
        private void BuildObject(int i)
        {
            var myGeometryModel = new GeometryModel3D();
            ...
        }
    }
