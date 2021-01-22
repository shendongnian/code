    var verticalFieldOfView = 60.0;    // Degrees
    var horizontalFieldOfView = 60.0;  // Degrees
    SceneApparentDistance = 1000.0;    // In global coordinate units
    SceneApparentHeight = image.Height * SceneApparentDistance * Math.Tan(verticalFieldOfView * Math.Pi/180));
    SceneApparentWidth = image.Width * SceneApparentDistance * Math.Tan(horizontalFieldOfView * Math.Pi/180));
