    public class Example
    {
        public Example()
        {
            for (int i = 0; i < 4; i++)
            {
                var thread = new Thread(
                    () =>
                    {
                        while (true)
                        {
                          if (/* between 9am and 6pm */)
                          {
                            Message message = queue.Receive();
                            Controller controller = new Controller(message, /* AutoResetEvent? */);
                            // Do whatever you need to with Contoller here.
                            // Is the AutoResetEvent really needed?
                          }
                        }
                    });
                thread.IsBackground = true;
                thread.Start();
            }
        }
    }
