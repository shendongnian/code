    [Guid("e4452b96-16ba-4e82-9342-aa37af1f5c26")] // IID
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWeatherStationV430 // IUnknown base interface is implicit
    {
        bool IsValid();
        float GetSurfaceWind();
        void SetSurfaceWind(float aVal);
        // etc...
    }
