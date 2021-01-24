    public static class DelayCall
    {
        public static EditorApplication.CallbackFunction ByNumberOfEditorFrames(int n, Action a)
        {
            EditorApplication.CallbackFunction callback = null;
    
            callback = new EditorApplication.CallbackFunction(() =>
            {
                if (n-- <= 0)
                {
                    a();
                }
                else
                {
                    EditorApplication.delayCall += callback;
                }
            });
    
            return callback;
        }
    }
