    var deserializedGetPaymentOptions = JsonConvert.DeserializeObject<Models.PaymentOptions>(await responseGetPaymentOptions.Content.ReadAsStringAsync());
                    foreach (var desPayOp in deserializedGetPaymentOptions.PaymentMethods) {
                        Debug.WriteLine("start foreach");
                        foreach (KeyValuePair<int, string> issuerFromDict in desPayOp.Options.Issuers)
                        {
                            Debug.WriteLine(issuerFromDict.Key.ToString() + " : " + issuerFromDict.Value);
                        }
                    }
