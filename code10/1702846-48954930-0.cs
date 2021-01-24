    public interface IHelper
    {
    	public void GetCameras(IList<Camera> cameras);
    	public Picture TakePicture(Camera camera);
        public void LoseCamera(Camera camera);
    }
    
    public class Camera
    {
    	public string Name { get; set; }
        public int BlaBla { get; set; }
    }
