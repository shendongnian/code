    [ActiveRecord]
    public class Camera : ActiveRecordBase<Camera>
    {
        [PrimaryKey]
        public int CameraId {get; set;}
        [BelongsTo]
        public CameraKit CamKit {get; set;}
        [Property]
        public string serialNo {get; set;}
    }
