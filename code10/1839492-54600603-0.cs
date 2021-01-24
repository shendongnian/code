    using System;
    using System.Linq;
    using System.IO;
    using System.Xml;
    namespace Parse_Returns_XML_To_SQL
    {
        class Program
        {
        static void Main(string[] args)
        {
            int counter = 0;
            try
            {
                MainGetSet mainGetSet = new MainGetSet();
                LineGetSet lineGetSet = new LineGetSet();
                
                foreach (string file in Directory.EnumerateFiles(@"C:\_Data\CostcoXML", "*.xml"))
                {
                    counter++;
                    string xmlContents = File.ReadAllText(file);
                    Console.WriteLine(file);
                    //Console.ReadKey();
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(xmlContents);
                    XmlNodeList RTVnodes = xmldoc.SelectNodes("memo-list/RTVMemo");
                    foreach (XmlNode rtv in RTVnodes)
                    {
                        //MessageBox.Show(rtv["deduction-num"].InnerText);
                        if (rtv["vendor-num"].InnerText.Length > 0)
                        {
                            mainGetSet.VendorNum1 = rtv["vendor-num"].InnerText;
                        }
                        if (rtv["dept-num"].InnerText.Length > 0)
                        {
                            mainGetSet.DeptNum1 = rtv["dept-num"].InnerText;
                        }
                        if (rtv["deduction-num"].InnerText.Length > 0)
                        {
                            mainGetSet.DeductionNum1 = rtv["deduction-num"].InnerText;
                            lineGetSet.DeductionNum1 = rtv["deduction-num"].InnerText;
                        }
                        if (rtv["ra-num"].InnerText.Length > 0)
                        {
                            mainGetSet.RaNum1 = rtv["ra-num"].InnerText;
                            lineGetSet.RaNum1 = rtv["ra-num"].InnerText;
                        }
                        if (rtv["date-shipped"].InnerText.Length > 0)
                        {
                            mainGetSet.DateShipped1 = rtv["date-shipped"].InnerText;
                        }
                        if (rtv["shipping-loc"].InnerText.Length > 0)
                        {
                            mainGetSet.ShippingLoc1 = rtv["shipping-loc"].InnerText;
                        }
                        if (rtv["carrier-name"].InnerText.Length > 0)
                        {
                            mainGetSet.CarrierName1 = rtv["carrier-name"].InnerText;
                            if (mainGetSet.CarrierName1.Trim().Contains("FREIGHT"))
                            {
                                lineGetSet.TrackOrTruck1 = "Freight";
                            }
                            else if (mainGetSet.CarrierName1.Trim().Contains("VEND"))
                            {
                                lineGetSet.TrackOrTruck1 = "Vendor";
                            }
                            else
                            {
                                lineGetSet.TrackOrTruck1 = "Track";
                            }
                        }
                        if (rtv["total-cases"].InnerText.Length > 0)
                        {
                            mainGetSet.TotalCases1 = rtv["total-cases"].InnerText;
                        }
                        if (rtv["total-weight"].InnerText.Length > 0)
                        {
                            mainGetSet.TotalWeight1 = rtv["total-weight"].InnerText;
                        }
                        if (rtv["tracking-num"].InnerText.Length > 0)
                        {
                            mainGetSet.TrackingNum1 = rtv["tracking-num"].InnerText;
                            lineGetSet.TrackingNum1 = rtv["tracking-num"].InnerText;
                        }
                        if (rtv["misc-charges-general"].InnerText.Length > 0)
                        {
                            mainGetSet.MiscChargesGeneral1 = rtv["misc-charges-general"].InnerText;
                        }
                        if (rtv["log-line-num"].InnerText.Length > 0)
                        {
                            mainGetSet.LogLineNum1 = rtv["log-line-num"].InnerText;
                        }
                        if (rtv["comment"].InnerText.Length > 0)
                        {
                            mainGetSet.Comment1 = rtv["comment"].InnerText;
                        }
                        if (rtv["merch-cost"].InnerText.Length > 0)
                        {
                            mainGetSet.MerchCost1 = rtv["merch-cost"].InnerText;
                        }
                        if (rtv["discount"].InnerText.Length > 0)
                        {
                            mainGetSet.Discount1 = rtv["discount"].InnerText;
                        }
                        if (rtv["misc-charges"].InnerText.Length > 0)
                        {
                            mainGetSet.MiscCharges1 = rtv["misc-charges"].InnerText;
                        }
                        if (rtv["freight-allowance"].InnerText.Length > 0)
                        {
                            mainGetSet.FreightAllowance1 = rtv["freight-allowance"].InnerText;
                        }
                        if (rtv["inbound-freight"].InnerText.Length > 0)
                        {
                            mainGetSet.InboundFreight1 = rtv["inbound-freight"].InnerText;
                        }
                        if (rtv["outbound-freight"].InnerText.Length > 0)
                        {
                            mainGetSet.OutboundFreight1 = rtv["outbound-freight"].InnerText;
                        }
                        if (rtv["ECommerceFrt"].InnerText.Length > 0)
                        {
                            mainGetSet.ECommerceFrt1 = rtv["ECommerceFrt"].InnerText;
                        }
                        if (rtv["total-amount"].InnerText.Length > 0)
                        {
                            mainGetSet.TotalAmount1 = rtv["total-amount"].InnerText;
                        }
                        if (rtv["gst-tax"].InnerText.Length > 0)
                        {
                            mainGetSet.GstTax1 = rtv["gst-tax"].InnerText;
                        }
                        if (rtv["qst-tax"].InnerText.Length > 0)
                        {
                            mainGetSet.QstTax1 = rtv["qst-tax"].InnerText;
                        }
                        if (rtv["hst-tax"].InnerText.Length > 0)
                        {
                            mainGetSet.HstTax1 = rtv["hst-tax"].InnerText;
                            ReturnsDB.AddReturnsToDB(mainGetSet);
                        }
                        XmlNodeList itemNodes = rtv.SelectNodes("item");
                        foreach (XmlNode item in itemNodes)
                        {
                            //MessageBox.Show(item["item-desc1"].InnerText);
                            if (item["quantity-returned"].InnerText.Length > 0)
                            {
                                lineGetSet.QuantityReturned1 = item["quantity-returned"].InnerText;
                            }
                            if (item["item-num"].InnerText.Length > 0)
                            {
                                lineGetSet.ItemNum1 = item["item-num"].InnerText;
                            }
                            if (item["item-desc1"].InnerText.Length > 0)
                            {
                                lineGetSet.ItemDesc11 = item["item-desc1"].InnerText;
                            }
                            if (item["net-cost"].InnerText.Length > 0)
                            {
                                lineGetSet.NetCost1 = item["net-cost"].InnerText;
                            }
                            if (item["extended-cost"].InnerText.Length > 0)
                            {
                                lineGetSet.ExtendedCost1 = item["extended-cost"].InnerText;
                                LinesDB.AddLinesToDB(lineGetSet);
                            }
                        }
                    }
                    string fileSplit = file.Split('\\').Last();
                    File.Move(file, @"C:\_Data\CostcoXML\Archive\" + fileSplit);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("There was an exception in the main program: " + exc);
            }
            Console.WriteLine("Finished writing from server.");
            Console.WriteLine(" Number of files written to our database (file in folder): " + counter);
            //Console.ReadKey();
            pause myPause = new pause();
            Console.WriteLine(DateTime.Now + " - Entering " + 10 + " Seconds. Pause");
            System.Threading.Thread.Sleep(10000);
            int timeOut = 10000;
            myPause.Pause(timeOut);
            // MessageBox.Show(timeOut.ToString());
            Console.WriteLine(DateTime.Now + " - Exiting Pause - Execute\r\n");
        }
    }
    }
