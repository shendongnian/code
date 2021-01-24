    public static class CollectionExtensions
    {
        public static void Insert<T>(this ObservableCollection<T> collection, MessageType messageType, IParticipant sender, string strText)  where T : MessageModel, new()
        {
            collection.Insert(0, new T()
            {
                MessageType = messageType,
                MessageDateTime = DateTime.Now,
                MessageSource = sender.ParticipantName,
                MessageText = strText
            });
        }
    }
