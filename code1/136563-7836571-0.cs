    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Globalization;
    using System.Net;
    using System.IO;
    using System.Text;
    
    namespace PayPal
    {
        public static class PaymentDataTransfer 
        {
            private const string AppSetting_Identity = "PayPal.PaymentDataTransfer.Identity";
            private const string AppSetting_ServiceUrl = "PayPal.PaymentDataTransfer.ServiceUrl";
    
            public class TransactionStatus
            {
                public bool Success { get; set; }
                public int ErrorCode { get; set; }
                public NameValueCollection Parameters { get; set; }
    
                public float PaymentGross { get; set; }
                public string Currency { get; set; }
    
                public string Invoice { get; set; }
                public PayerInformation Payer { get; set; }
                public CartItem[] CartItems;
            }
    
            public class PayerInformation
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
            }
    
            public class CartItem
            {
                public int Number { get; set; }
                public string Name { get; set; }
                public int Qunatity { get; set; }
                public float GrossPrice { get; set; }
            }
    
            public static TransactionStatus GetTransactionStatus(string transactionToken)
            {
                return GetTransactionStatus(transactionToken, false);
            }
    
            public static TransactionStatus GetTransactionStatus(string transactionToken, bool sandbox)
            {
    
    #if ParsingTest
                string response =
                    @"SUCCESS
    mc_gross=1100.00
    invoice=334354
    protection_eligibility=Eligible
    address_status=confirmed
    item_number1=1
    tax=0.00
    item_number2=2
    payer_id=DSFSDFSDFSDF
    address_street=1+Main+St
    payment_date=04%3A13%3A49+Oct+20%2C+2011+PDT
    payment_status=Completed
    charset=windows-1252
    address_zip=95131
    mc_shipping=0.00
    mc_handling=0.00
    first_name=Test
    mc_fee=32.20
    address_country_code=US
    address_name=Test+User
    custom=
    payer_status=verified
    business=yourbusiness%40business.com
    address_country=United+States
    num_cart_items=2
    mc_handling1=0.00
    mc_handling2=0.00
    address_city=San+Jose
    payer_email=payer_email%40business.com
    mc_shipping1=0.00
    mc_shipping2=0.00
    txn_id=0SDFSDFSDFSDFD
    payment_type=instant
    last_name=User
    address_state=CA
    item_name1=First+test+item
    receiver_email=yourbusiness%40business.com
    item_name2=Second+test+item
    payment_fee=32.20
    quantity1=1
    quantity2=1
    receiver_id=SDFGDFGDFGDFDFG
    txn_type=cart
    mc_gross_1=1000.00
    mc_currency=USD
    mc_gross_2=100.00
    residence_country=US
    transaction_subject=Shopping+Cart
    payment_gross=1100.00";
    
    #else
                string authToken = GetAppSetting(AppSetting_Identity, sandbox);
                string serviceUrl = GetAppSetting(AppSetting_ServiceUrl, sandbox);
                string query = string.Format("cmd=_notify-synch&tx={0}&at={1}", transactionToken, authToken);
    
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceUrl);
    
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = query.Length;
    
                using (var requestStreamWriter = new StreamWriter(request.GetRequestStream(), Encoding.ASCII))
                {
                    requestStreamWriter.Write(query);
                    requestStreamWriter.Close();
                }
    
                string response;
    
                // Do the request to PayPal and get the response
                using(StreamReader stIn = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    response = stIn.ReadToEnd();
                    stIn.Close();
                }
    #endif
    
                string[] lines = response.Split(new []{"\n", "\r\n"}, StringSplitOptions.None); // splitting up by line breaks
    
                var result = new TransactionStatus
                                 {
                                     Success = lines[0] == "SUCCESS",
                                     Parameters = new NameValueCollection()
                                 };
    
                for(int i=1; i < lines.Length; i++)
                {
                    string line = lines[i];
    
                    string[] keyValuePair = lines[i].Split(new [] {'='});
    
                    if(keyValuePair.Length == 2)
                    {
                        result.Parameters.Add(UrlDecode(keyValuePair[0]), UrlDecode(keyValuePair[1]));
                    } 
                    else
                    {
                        const string errorCodePrefix = "Error:";
    
                        if(line.StartsWith(errorCodePrefix))
                        {
                            result.ErrorCode = Int32.Parse(line.Substring(errorCodePrefix.Length));
                        }
                    }
                }
    
                if(result.Success)
                {
                    result.Invoice = result.Parameters["invoice"];
    
                    result.Payer = new PayerInformation
                                       {
                                           FirstName = result.Parameters["first_name"],
                                           LastName = result.Parameters["last_name"],
                                           Email = result.Parameters["payer_email"]
                                       };
    
                    float paymentGross;
                    result.PaymentGross = float.TryParse(result.Parameters["mc_gross"], 
                                          NumberStyles.Float, 
                                          CultureInfo.InvariantCulture, 
                                          out paymentGross) ? paymentGross : 0.0f;
    
                    result.Currency = result.Parameters["mc_currency"];
    
                    int cartItemsNumber;
                    if (int.TryParse(result.Parameters["num_cart_items"], out cartItemsNumber) && cartItemsNumber > 0)
                    {
                        var cartItems = new List<CartItem>();
    
                        for(int i=1; i <= cartItemsNumber; i++)
                        {
                            cartItems.Add(new CartItem
                                              {
                                                  Number = int.Parse(result.Parameters["item_number" + i], CultureInfo.InvariantCulture),
                                                  Name =  result.Parameters["item_name" + i],
                                                  Qunatity = int.Parse(result.Parameters["quantity" + i], CultureInfo.InvariantCulture),
                                                  GrossPrice = float.Parse(result.Parameters["mc_gross_" + i], CultureInfo.InvariantCulture)
                                              });
                        }
    
                        result.CartItems = cartItems.ToArray();
                    }
                }
    
                return result;
            }
    
            private static string UrlDecode(string encodedText)
            {
                return Uri.UnescapeDataString(encodedText.Replace("+", " "));
            }
    
            private static string GetAppSetting(string settingName, bool sandbox)
            {
                return ConfigurationManager.AppSettings[settingName + (sandbox ? "_sandbox" : string.Empty)];
            }
        }
    }
