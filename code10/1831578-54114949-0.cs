    class CustomObject : ICloneable
    {
        ... your implementation
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    
    CustomObject obj = new CustomObject();
    CustomObject backupObj = (CustomerObject) obj.Clone(); //backup
    ...
    // later restore
    obj = backupObj
