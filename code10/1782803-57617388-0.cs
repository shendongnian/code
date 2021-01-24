            var binding = GetCustomBinding();
    		private Binding GetCustomBinding()
    		{
    			CustomBinding result = new CustomBinding();
    			TextMessageEncodingBindingElement textBindingElement = new TextMessageEncodingBindingElement();
    			result.Elements.Add(textBindingElement);
    			HttpsTransportBindingElement httpsBindingElement = new HttpsTransportBindingElement
    			{
    				AllowCookies = true,
    				MaxBufferSize = int.MaxValue,
    				MaxReceivedMessageSize = int.MaxValue,
    				AuthenticationScheme = System.Net.AuthenticationSchemes.Negotiate
    			};
    			result.Elements.Add(httpsBindingElement);
    			return result;
    		}
