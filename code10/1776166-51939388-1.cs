    public class UDPSender
    {
        private Timer _timerstuff;
        ...
        public void SendUDPContinuously(int delayMiliseconds)
        {
            _timerstuff = new Timer(sate => SendUDPOnce(), null, 0, delayMiliseconds);
        }                           
        ...
    }
