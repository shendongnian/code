    void LateUpdate()
    {
        ...
        if (inputFlag_AnalogStickInput)
        {
            OnLateUpdateOnAnalogStickInput.Invoke(mInputDirection, normalizedInputMag);
        }
    }
