        private static bool CreateTopicIfNotExist(Producer producer, string topicName)
        {
            bool isTopicExist = producer.GetMetadata().Topics.Any(t => t.Topic == topicName);
            if (!isTopicExist)
            {
                //Creates topic if it is not exist; Only in case of auto.create.topics.enable = true is set into kafka configuration
                var topicMetadata = producer.GetMetadata(false, topicName).Topics.FirstOrDefault();
                if (topicMetadata != null && (topicMetadata.Error.Code != ErrorCode.UnknownTopicOrPart || topicMetadata.Error.Code == ErrorCode.Local_UnknownTopic))
                    isTopicExist = true;
            }
            return isTopicExist;
        }
