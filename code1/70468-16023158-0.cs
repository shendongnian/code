    public static class DispatcherExtentions
    {
        public static void PumpUntilDry(this Dispatcher dispatcher)
        {
            DispatcherFrame frame = new DispatcherFrame();
            dispatcher.BeginInvoke(
                new Action(() => frame.Continue = false),
                DispatcherPriority.Background);
            Dispatcher.PushFrame(frame);
        }
    }
