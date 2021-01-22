        /// <summary>
        /// Returns the client IP 
        /// </summary>
        public static string ClientIP
        {
            get
            {
                // determine IP address takes < 1ms
                OperationContext context = OperationContext.Current;
                MessageProperties messageProperties = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpointProperty =
                    messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                return endpointProperty.Address;
            }
        }
