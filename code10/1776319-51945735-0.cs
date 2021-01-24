    void OnAudioFilterRead(float[] data, int channels)
    {
        AndroidJNI.AttachCurrentThread();
        if (ok)
        {
            if (obj == null)
            {
                obj = new AndroidJavaObject("com.xx.aop.media.av.GPUFrameCapturer");
                Debug.Log(obj.Call<bool>("isRecording"));
            }
        }
        AndroidJNI.DetachCurrentThread()
    }
