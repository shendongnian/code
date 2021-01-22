    /// <summary>
    /// Does stuff
    /// </summary>
    /// <param name="classInstanceRef">some documentation</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="classInstanceRef"/> is null.</exception>
    public void f(Class classInstanceRef)
    {
      if (classInstanceRef == null)
        throw new ArgumentNullException("classInstanceRef");
    }
