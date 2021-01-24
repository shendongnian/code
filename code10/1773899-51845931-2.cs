    class MessageListener<T> where T : BaseDto {
        public void GetMessage<T>(Action<T> action)
        {
        }
    
        MessageListener<T>(string queueToListen)
        {
        }
    }
