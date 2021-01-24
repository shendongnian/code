    private void VerifyNotClosing()
    {
        if (_isClosing == true)
        {
            throw new InvalidOperationException(SR.Get(SRID.InvalidOperationDuringClosing));
        }
     
        if (IsSourceWindowNull == false && IsCompositionTargetInvalid == true)
        {
            throw new InvalidOperationException(SR.Get(SRID.InvalidCompositionTarget));
        }
    }
