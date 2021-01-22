    MixerLine mixerLine;
    if (waveInHandle != IntPtr.Zero)
    {
        mixerLine = new MixerLine(waveInHandle, 0, MixerFlags.WaveInHandle);
    }
    else
    {
        mixerLine = new MixerLine((IntPtr)waveInDeviceNumber, 0, MixerFlags.WaveIn);
    }
    foreach (MixerControl control in mixerLine.Controls)
    {
        if (control.ControlType == MixerControlType.Volume)
        {
            // this is the volume control of the "destination"
            UnsignedMixerControl volumeControl = (UnsignedMixerControl)control;
            Debug.WriteLine(volumeControl.Percent.ToString());
        }      
    }
    // to examine the volume controls of the "sources":
    if (source.ComponentType == MixerLineComponentType.SourceMicrophone)
    {
        foreach (MixerControl control in source.Controls)
        {
            if (control.ControlType == MixerControlType.Volume)
            {
                // this might be the one you want to set
            }
        }
    }
