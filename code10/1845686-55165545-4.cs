                var client = new ManagementClient(AppConfig.BaseAddress, AppConfig.RabbitUsername, AppConfig.RabbitPassword);
                var vhost = client.GetVhostAsync("/").Result;
                var aliveRes = client.IsAliveAsync(vhost).Result;
                var errQueue = client.GetQueueAsync(Constants.EasyNetQErrorQueueName, vhost).Result;
                var crit = new GetMessagesCriteria(long.MaxValue, Ackmodes.ack_requeue_false);
                var errMsgs = client.GetMessagesFromQueueAsync(errQueue, crit).Result;
                foreach (var errMsg in errMsgs)
                {
                    var innerMsg = JsonConvert.DeserializeObject<Error>(errMsg.Payload);
                    var pubInfo = new PublishInfo(innerMsg.RoutingKey, innerMsg.Message);
                    pubInfo.Properties.Add("type", innerMsg.BasicProperties.Type);
                    pubInfo.Properties.Add("correlation_id", innerMsg.BasicProperties.CorrelationId);
                    pubInfo.Properties.Add("delivery_mode", innerMsg.BasicProperties.DeliveryMode);
                    var pubRes = client.PublishAsync(client.GetExchangeAsync(innerMsg.Exchange, vhost).Result,
                         pubInfo).Result;
                }
