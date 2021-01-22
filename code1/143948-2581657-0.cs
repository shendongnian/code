    [DataContract]
    public class CameraData
    {
        ...
        public Camera ToCamera() { ... }
        public static CameraData FromCamera(Camera c) { ... }
    }
