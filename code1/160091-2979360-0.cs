    ...
    <Viewport3DVisual>
      <!-- the camera -->
      <Viewport3DVisual.Camera>
        <PerspectiveCamera ... camera parameters ... />
      </Viewport3DVisual.Camera>
      <ModelVisual3D>
        <ModelVisual3D.Content>
          <Model3DGroup>
            <!-- the light -->
            <AmbientLight ... light parameters ... />
            <!-- the car model -->
            <Model3DGroup>
              <Model3DGroup.Transform>
                <Transform3DGroup>
                  <ScaleTransform3D    ... scale car to proper size ... />
                  <RotateTransform3D   ... face car in proper direction ... />
                  <TranslateTranform3D ... move car to proper global coordinates ... />
                </Transform3DGroup>
              </Model3DGroup.Transform>
              ... GeometryModel3D or Model3DGroup for the car model goes here ...
            </Model3DGroup>
            <!-- the scene image -->
            <GeometryModel3D>
              <GeometryModel3D.Material>
                <ImageBrush ImageSource=... scene image ... />
              </GeometryModel3D.Material>
              <GeometryModel3D.Geometry>
                <MeshGeometry3D Positions="0,0,0 1,0,0 1,1,0 0,1,0" Indices="0,1,2 2,3,0" />
              </GeometryModel3D.Geometry>
              <GeometryModel3D.Transform>
                <Transform3DGroup>
                  <ScaleTransform3D     ... scale scene to apparent size ... />
                  <TranslateTransform3D ... translate scene along Z axis to apparent distance from camera ... />
                  <RotateTransform3D    ... rotate distanced scene to original camera orientation ... />
                  <TranslateTransform3D ... move to global coordinates of original camera location ... />
                </Transform3DGroup>
              </GeometryModel3D.Transform>
            </GeometryModel3D>
          </Model3DGroup>
        </ModelVisual3D.Content>
      </ModelVisual3D>
    </Viewport3DVisual>
