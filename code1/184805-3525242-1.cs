    public class Example
    {
        private BlockingCollection<Controller> m_Queue = new BlockingCollection<Controller>();
        public Example()
        {
            for (int i = 0; i < 4; i++)
            {
                var thread = new Thread(
                    () =>
                    {
                        while (true)
                        {
                            Controller controller = m_Queue.Take();
                            // Do whatever you need to with Contoller here.
                        }
                    });
                thread.IsBackground = true;
                thread.Start();
            }
        }
        public void Exec()
        {
            try
            {
                AutoResetEvent autoEvent = new AutoResetEvent(false);
                int vQtd = Queue.GetAllMessages().Length
                while (vQtd > 0)
                {
                    m_Queue.Add(new Controller(Queue.Receive(), autoEvent));
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "RECOVERABLE");
            }
        }
    }
