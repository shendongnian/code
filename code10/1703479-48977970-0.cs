    private Ray getClickRay(Vector2 clickLocation, Viewport viewport, Matrix view, Matrix projection)
    			{
    			Vector3 nearPoint = viewport.Unproject(new Vector3(clickLocation.X, clickLocation.Y, 0.0f), projection, view, Matrix.Identity);
    			Vector3 farPoint = viewport.Unproject(new Vector3(clickLocation.X, clickLocation.Y, 1.0f), projection, view, Matrix.Identity);
                Vector3 direction = farPoint - nearPoint;
    
    			direction.Normalize();
     
    			return new Ray(nearPoint, direction);
    			}
