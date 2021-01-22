                /* Add Headers */
                        MessageHeader header
                = MessageHeader.CreateHeader(
                "Service-Bound-CustomHeader",
                "http://Microsoft.WCF.Documentation",
                "Custom Happy Value."
                );
                        header = MessageHeader.CreateHeader(
                    "Service-Bound-OneWayHeader",
                    "http://Microsoft.WCF.Documentation",
                    "Different Happy Value."
                  );
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
               
                Console.WriteLine(abc.GetData(100));
                Console.WriteLine(abc.GetDataUsingDataContract(new ServiceReference1.CompositeType()).ToString());
            }
            
------------------------------------------------------------------------
