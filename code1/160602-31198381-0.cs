    udfSetPropertyG("Mail Status", GlobalVariables.sPaymentClose, mailitem);
         public void udfSetPropertyG(string sPropName, string sPropValue, OutLook.MailItem mailItem)
                {
                    OutLook.UserProperty oOlProperty = default(OutLook.UserProperty);
                    oOlProperty = mailItem.UserProperties.Add(sPropName, OutLook.OlUserPropertyType.olText);
                    if ((oOlProperty == null))
                    {
                        oOlProperty = mailItem.UserProperties.Add(sPropName, OutLook.OlUserPropertyType.olText);
                    }
                    oOlProperty.Value = sPropValue;
                }
