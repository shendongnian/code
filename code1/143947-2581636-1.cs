    public static class CameraExtensions
    {
        public static CameraData ToCameraData(this Camera camera)
        {
            return Mapper.Map<Camera, CameraData>(camera);
        }
    }
