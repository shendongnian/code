    int frameCount = trace.Framecount;
    for (int i=0;i<frameCount;++i)
    {
         var frame = trace.GetFrame(i);
         // Write properties to formatted HTML, including frame.GetMethod()/frame.GetFileName(), etc.
         // The specific format is really up to you.
    }
