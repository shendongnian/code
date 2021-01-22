    #if USE_FLOAT
    public struct MyNumber : NumberContainer<float>
    #else
    public struct MyNumber : NumberContainer<double>
    #endif
    {
    }
