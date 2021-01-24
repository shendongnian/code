    /// <summary>
    /// With Windows 10 update 1803 came an option to deny access to the microphones on an OS level.
    /// The option covers all soundcards installed into the PC (Magnum/Callisto is a soundcard)
    /// </summary>
    public static class MicrophonePrivacyProbe
    {
      /// <summary>
      /// Test if Microphone Privacy Settings are to restrictive for microphone access.
      /// </summary>
      /// <returns>True if microphone is accessible</returns>
      public static bool Allowed()
      {
        bool access = false;
        var devices = new CaptureDevicesCollection();
        if ( devices?.Count <= 0 ) return false;
        var captureDevice = new Capture(devices[0].DriverGuid);
        CaptureBuffer applicationBuffer = null;
        var inputFormat = new WaveFormat();
        inputFormat.AverageBytesPerSecond = 8000;
        inputFormat.BitsPerSample = 8;
        inputFormat.BlockAlign = 1;
        inputFormat.Channels = 1;
        inputFormat.FormatTag = WaveFormatTag.Pcm;
        inputFormat.SamplesPerSecond = 8000;
        CaptureBufferDescription bufferdesc = new CaptureBufferDescription();
        bufferdesc.BufferBytes = 200;
        bufferdesc.Format = inputFormat; 
        try
        {
          applicationBuffer = new CaptureBuffer(bufferdesc, captureDevice);
          access = true;
        }
        catch (SoundException e)
        {
        }
        finally
        {
          applicationBuffer?.Dispose();
          captureDevice?.Dispose();
        }
        return access;
      }
    }
