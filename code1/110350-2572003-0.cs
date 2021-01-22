    public static Complex Add(Complex left, Complex right)
    {
        return new Complex(left.Real + right.Real, left.Imaginary + right.Imaginary);
    }
    public static Complex operator +(Complex left, Complex right)
    {
        return new Complex(left.Real + right.Real, left.Imaginary + right.Imaginary);
    }
