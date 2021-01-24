    // camera view horizontal check
    if (player.X < cameraView.X || player.X + player.Width > cameraview.X + cameraView.Width) 
    {
        player.MoveX();
    }
    
    // camera view vertical check
    if (player.Y < cameraView.Y || player.Y + player.Height > cameraview.Y + cameraView.Height) 
    {
        player.MoveY();
    }
