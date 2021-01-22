    using (ITimeline timeline = new DefaultTimeline(25))
    {
        IGroup group = timeline.AddVideoGroup(32, 160, 100);
     
        ITrack videoTrack = group.AddTrack();
        IClip clip1 = videoTrack.AddImage("image1.jpg", 0, 2);
        IClip clip2 = videoTrack.AddImage("image2.jpg", 0, 2);
        IClip clip3 = videoTrack.AddImage("image3.jpg", 0, 2);
        IClip clip4 = videoTrack.AddImage("image4.jpg", 0, 2);
     
        double halfDuration = 0.5;
     
        group.AddTransition(clip2.Offset - halfDuration, halfDuration, StandardTransitions.CreateFade(), true);
        group.AddTransition(clip2.Offset, halfDuration, StandardTransitions.CreateFade(), false);
     
        group.AddTransition(clip3.Offset - halfDuration, halfDuration, StandardTransitions.CreateFade(), true);
        group.AddTransition(clip3.Offset, halfDuration, StandardTransitions.CreateFade(), false);
     
        group.AddTransition(clip4.Offset - halfDuration, halfDuration, StandardTransitions.CreateFade(), true);
        group.AddTransition(clip4.Offset, halfDuration, StandardTransitions.CreateFade(), false);
     
        ITrack audioTrack = timeline.AddAudioGroup().AddTrack();
     
        IClip audio =
            audioTrack.AddAudio("soundtrack.wav", 0, videoTrack.Duration);
     
        audioTrack.AddEffect(0, audio.Duration,
                            StandardEffects.CreateAudioEnvelope(1.0, 1.0, 1.0, audio.Duration));
     
        using (
            WindowsMediaRenderer renderer =
                new WindowsMediaRenderer(timeline, "output.wmv", WindowsMediaProfiles.HighQualityVideo))
        {
            renderer.Render();
        }
    }
