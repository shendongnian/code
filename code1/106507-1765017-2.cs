        public override void OnStop()
        {
            lock (syncObject)
            {
                if (stopping || stopped)
                {
                    Helper.WriteToLog(logger, Level.INFO,
                        string.Format("{0} {1}", TASK_NAME, "is already stopped."));
                    return;
                }
                stopping = true;
            }
        }
