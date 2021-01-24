    public interface IRotatable
    {
        RotationRange RotationRange { get; }
        // This must be valid according to RotationRange
        void Rotate(float angle);
    }
