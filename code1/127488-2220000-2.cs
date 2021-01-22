    /// <summary>
    /// Draws the <see cref="Control"/> to an <see cref="Image"/>
    /// </summary>
    /// <param name="control">The <see cref="Control"/> to draw.</param>
    /// <returns>An <see cref="Image"/> of the <see cref="Control"/></returns>
    public static Image DrawToImage(this Control control)
    {
        return Utilities.CaptureWindow(control.Handle);
    }
