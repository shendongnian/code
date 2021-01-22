			// API endpoint for the Refund call in the Sandbox
			string sAPIEndpoint = "https://svcs.sandbox.paypal.com/AdaptivePayments/Pay";
			// Version that you are coding against
			string sVersion = "1.1.0";
			// Error Langugage
			string sErrorLangugage = "en_US";
			// Detail Level
			string sDetailLevel = "ReturnAll";
			// Request Data Binding
			string sRequestDataBinding = "XML";
			// Response Data Binding
			string sResponseDataBinding = "XML";
			// Application ID
			string sAppID = "APP-80W284485P519543T";
			// other clientDetails fields
			string sIpAddress = "255.255.255.255";
			string sPartnerName = "MyCompanyName";
			string sDeviceID = "255.255.255.255";
			// Currency Code
			string sCurrencyCode = "USD";
			// Action Type
			string sActionType = "PAY";
			// ReturnURL and CancelURL used for approval flow
			string sReturnURL = "https://MyReturnURL";
			string sCancelURL = "https://MyCancelURL";
			// who pays the fees
			string sFeesPayer = "EACHRECEIVER";
			// memo field
			string sMemo = "testing my first pay call";
			// transaction amount
			string sAmount = "5";
			// supply your own sandbox accounts for receiver and sender
			string sTrackingID = System.Guid.NewGuid().ToString();
			// construct the XML request string
			StringBuilder sRequest = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
			sRequest.Append("<PayRequest xmlns:ns2=\"http://svcs.paypal.com/types/ap\">");
			// requestEnvelope fields
			sRequest.Append("<requestEnvelope><errorLanguage>");
			sRequest.Append(sErrorLangugage);
			sRequest.Append("</errorLanguage><detailLevel>");
			sRequest.Append(sDetailLevel);
			sRequest.Append("</detailLevel></requestEnvelope>");
			// clientDetails fields
			sRequest.Append("<clientDetails><applicationId>");
			sRequest.Append(sAppID);
			sRequest.Append("</applicationId><deviceId>");
			sRequest.Append(sDeviceID);
			sRequest.Append("</deviceId><ipAddress>");
			sRequest.Append(sIpAddress);
			sRequest.Append("</ipAddress><partnerName>");
			sRequest.Append(sPartnerName);
			sRequest.Append("</partnerName></clientDetails>");
			// request specific data fields
			sRequest.Append("<actionType>");
			sRequest.Append(sActionType);
			sRequest.Append("</actionType><cancelUrl>");
			sRequest.Append(sCancelURL);
			sRequest.Append("</cancelUrl><returnUrl>");
			sRequest.Append(sReturnURL);
			sRequest.Append("</returnUrl><currencyCode>");
			sRequest.Append(sCurrencyCode);
			sRequest.Append("</currencyCode><feesPayer>");
			sRequest.Append(sFeesPayer);
			sRequest.Append("</feesPayer><memo>");
			sRequest.Append(sMemo);
			sRequest.Append("</memo><receiverList><receiver><amount>");
			sRequest.Append(sAmount);
			sRequest.Append("</amount><email>");
			sRequest.Append(Receiver);
			sRequest.Append("</email></receiver></receiverList><senderEmail>");
			sRequest.Append(Sender);
			sRequest.Append("</senderEmail><trackingId>");
			sRequest.Append(sTrackingID);
			sRequest.Append("</trackingId></PayRequest>");
			// get ready to make the call
			HttpWebRequest oPayRequest = (HttpWebRequest)WebRequest.Create(sAPIEndpoint);
			oPayRequest.Method = "POST";
			byte[] array = Encoding.UTF8.GetBytes(sRequest.ToString());
			oPayRequest.ContentLength = array.Length;
			oPayRequest.ContentType = "text/xml;charset=utf-8";
			// set the HTTP Headers
			oPayRequest.Headers.Add("X-PAYPAL-SECURITY-USERID", UserID);
			oPayRequest.Headers.Add("X-PAYPAL-SECURITY-PASSWORD", Pass);
			oPayRequest.Headers.Add("X-PAYPAL-SECURITY-SIGNATURE", Signature);
			oPayRequest.Headers.Add("X-PAYPAL-SERVICE-VERSION", sVersion);
			oPayRequest.Headers.Add("X-PAYPAL-APPLICATION-ID", sAppID);
			oPayRequest.Headers.Add("X-PAYPAL-REQUEST-DATA-FORMAT", sRequestDataBinding);
			oPayRequest.Headers.Add("X-PAYPAL-RESPONSE-DATA-FORMAT", sResponseDataBinding);
			// send the request
			Stream oStream = oPayRequest.GetRequestStream();
			oStream.Write(array, 0, array.Length);
			oStream.Close();
			// get the response
			HttpWebResponse oPayResponse = (HttpWebResponse)oPayRequest.GetResponse();
			StreamReader oStreamReader = new StreamReader(oPayResponse.GetResponseStream());
			string sResponse = oStreamReader.ReadToEnd();
			oStreamReader.Close();
