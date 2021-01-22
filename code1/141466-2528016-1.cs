    protected void AdjustPrimaryColor(PrimaryColor pc, Func<byte, byte> adjustFunc)
    {
        switch (pc)
        {
            case PrimaryColor.Red:
                internalColor.R = adjustFunc(internalColor.R);
            case PrimaryColor.Green:
                internalColor.G = adjustFunc(internalColor.G);
            default:
                Debug.Assert(pc == PrimaryColor.Blue,
                    "Unexpected PrimaryColor value in AdjustPrimaryColor.");
                internalColor.B = adjustFunc(internalColor.B);
        }
    }
