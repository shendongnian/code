        public static bool IsDragging()
        {
            StackFrame[] frames = new StackTrace(false).GetFrames();
            foreach (StackFrame frame in frames)
            {
                System.Reflection.MethodBase mb = frame.GetMethod();
                if (mb.Module.Name == "System.Windows.Forms.dll" && mb.Name == "DoDragDrop")
                    return true;
            }
            return false;
        }
