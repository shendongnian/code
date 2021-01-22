    if (validateImageData)
    {
        num = SafeNativeMethods.Gdip.GdipImageForceValidation(new HandleRef(null, zero));
        if (num != 0)
        {
            SafeNativeMethods.Gdip.GdipDisposeImage(new HandleRef(null, zero));
            throw SafeNativeMethods.Gdip.StatusException(num);
        }
    }
