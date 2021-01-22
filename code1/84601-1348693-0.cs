The constructor new StackFrame(1) you'd call would do this:
    private void BuildStackFrame(int skipFrames, bool fNeedFileInfo)
    {
        StackFrameHelper sfh = new StackFrameHelper(fNeedFileInfo, null);
        StackTrace.GetStackFramesInternal(sfh, 0, null);
        int numberOfFrames = sfh.GetNumberOfFrames();
        skipFrames += StackTrace.CalculateFramesToSkip(sfh, numberOfFrames);
        if ((numberOfFrames - skipFrames) > 0)
        {
            this.method = sfh.GetMethodBase(skipFrames);
            this.offset = sfh.GetOffset(skipFrames);
            this.ILOffset = sfh.GetILOffset(skipFrames);
            if (fNeedFileInfo)
            {
                this.strFileName = sfh.GetFilename(skipFrames);
                this.iLineNumber = sfh.GetLineNumber(skipFrames);
                this.iColumnNumber = sfh.GetColumnNumber(skipFrames);
            }
        }
    }
GetStackFramesInternal is an external method.  CalculateFramesToSkip has a loop that operates exactly once, since you specified only 1 frame.  Everything else looks pretty quick.
