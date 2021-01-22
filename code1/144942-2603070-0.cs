    namespace Program
    {
        class ReJoice
        {
            public void End() //This does not automatically re-raise the exception if caught.  
            {
                throw new Exception();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    ReJoice x = new ReJoice();
                    x.End();
                }
                catch (Exception e) {
                   throw e;
                }
            }
        }
    }
