    using System;
    using System.Collections.Generic;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using RabbitMQ.Client;
    
    namespace com.rabbitmq.consumers
    {
        public sealed class ObservableConsumer : IBasicConsumer
        {
            private readonly List<string> _consumerTags = new List<string>();
            private readonly object _consumerTagsLock = new object();
            private readonly Subject<Message> _subject = new Subject<Message>();
    
            public ushort PrefetchCount { get; set; }
            public IEnumerable<string> ConsumerTags { get { return new List<string>(_consumerTags); } }
    
            /// <summary>
            /// Registers this consumer on the given queue. 
            /// </summary>
            /// <returns>The consumer tag assigned.</returns>
            public string ConsumeFrom(IModel channel, string queueName)
            {
                Model = channel;
                return Model.BasicConsume(queueName, false, this);
            }
    
            /// <summary>
            /// Contains an observable of the incoming messages where messages are processed on a thread pool thread.
            /// </summary>
            public IObservable<Message> IncomingMessages
            {
                get { return _subject.ObserveOn(Scheduler.ThreadPool); }
            }
    
            ///<summary>Retrieve the IModel instance this consumer is
            ///registered with.</summary>
            public IModel Model { get; private set; }
    
            ///<summary>Returns true while the consumer is registered and
            ///expecting deliveries from the broker.</summary>
            public bool IsRunning
            {
                get { return _consumerTags.Count > 0; }
            }
    
            /// <summary>
            /// Run after a consumer is cancelled.
            /// </summary>
            /// <param name="consumerTag"></param>
            private void OnConsumerCanceled(string consumerTag)
            {
    
            }
    
            /// <summary>
            /// Run after a consumer is added.
            /// </summary>
            /// <param name="consumerTag"></param>
            private void OnConsumerAdded(string consumerTag)
            {
    
            }
    
            public void HandleBasicConsumeOk(string consumerTag)
            {
                lock (_consumerTagsLock) {
                    if (!_consumerTags.Contains(consumerTag))
                        _consumerTags.Add(consumerTag);
                }
            }
    
            public void HandleBasicCancelOk(string consumerTag)
            {
                lock (_consumerTagsLock) {
                    if (_consumerTags.Contains(consumerTag)) {
                        _consumerTags.Remove(consumerTag);
                        OnConsumerCanceled(consumerTag);
                    }
                }
            }
    
            public void HandleBasicCancel(string consumerTag)
            {
                lock (_consumerTagsLock) {
                    if (_consumerTags.Contains(consumerTag)) {
                        _consumerTags.Remove(consumerTag);
                        OnConsumerCanceled(consumerTag);
                    }
                }
            }
    
            public void HandleModelShutdown(IModel model, ShutdownEventArgs reason)
            {
                //Don't need to do anything.
            }
    
            public void HandleBasicDeliver(string consumerTag,
                                           ulong deliveryTag,
                                           bool redelivered,
                                           string exchange,
                                           string routingKey,
                                           IBasicProperties properties,
                                           byte[] body)
            {
                //Hack - prevents the broker from sending too many messages.
                //if (PrefetchCount > 0 && _unackedMessages.Count > PrefetchCount) {
                //    Model.BasicReject(deliveryTag, true);
                //    return;
                //}
    
                var message = new Message(properties.HeaderFromBasicProperties()) { Content = body };
                var deliveryData = new MessageDeliveryData()
                {
                    ConsumerTag = consumerTag,
                    DeliveryTag = deliveryTag,
                    Redelivered = redelivered,
                };
    
                message.Tag = deliveryData;
    
                if (AckMode != AcknowledgeMode.AckWhenReceived) {
                    message.Acknowledged += messageAcknowledged;
                    message.Failed += messageFailed;
                }
    
                _subject.OnNext(message);
            }
    
            void messageFailed(Message message, Exception ex, bool requeue)
            {
                try {
                    message.Acknowledged -= messageAcknowledged;
                    message.Failed -= messageFailed;
    
                    if (message.Tag is MessageDeliveryData) {
                        Model.BasicNack((message.Tag as MessageDeliveryData).DeliveryTag, false, requeue);
                    }
                }
                catch {}
            }
    
            void messageAcknowledged(Message message)
            {
                try {
                    message.Acknowledged -= messageAcknowledged;
                    message.Failed -= messageFailed;
    
                    if (message.Tag is MessageDeliveryData) {
                        var ackMultiple = AckMode == AcknowledgeMode.AckAfterAny;
                        Model.BasicAck((message.Tag as MessageDeliveryData).DeliveryTag, ackMultiple);
                    }
                }
                catch {}
            }
        }
    }
