    Storyboard storyboard3 = new Storyboard();
    storyboard3.AutoReverse = false;
    Rotation3DAnimationUsingKeyFrames r3d = new Rotation3DAnimationUsingKeyFrames();
    r3d.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
    r3d.Duration = new TimeSpan(0,0,0,1,0);
    r3d.KeyFrames.Add(new SplineRotation3DKeyFrame(new AxisAngleRotation3D(new Vector3D(1,0,0),1)));
    r3d.KeyFrames.Add(new SplineRotation3DKeyFrame(new AxisAngleRotation3D(new Vector3D(1, 0, 0), 37)));
    r3d.Name = "r3d";
           
    Storyboard.SetTargetName(r3d, "DefaultGroup");
    Storyboard.SetTargetProperty(r3d, new PropertyPath("(Visual3D.Transform).(Transform3DGroup.Children)[2].(RotateTransform3D.Rotation)")); 
         
    storyboard3.Children.Add(r3d);
    this.BeginStoryboard(storyboard3);
