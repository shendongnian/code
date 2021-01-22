    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Printing;
    using System.Text;
    using System.Windows;
    using System.Xml;
    
    // Adapted
    // From: XPS Printing, Tray selection and InputBinCapability (InputBin) = Problem
    // Link: http://www.windows-tech.info/14/29c7cf575646cb39.php - last answer at bottom by Jo0815
    
    namespace WpfApplication1
    {
        public static class WpfPrinterUtilities
        {
            #region GetPrintQueues
    
            /// <summary>
            /// Gets a dictionary of print queues where Key = print queue name
            /// and Value = the print queue object.
            /// </summary>
            /// <param name="printQueueTypes">EnumeratedPrintQueueTypes params array of the types of print queues being requested.</param>
            /// <returns>Dictionary of requested print queues where Key = print queue name and Value = the print queue object itself.</returns>
            public static Dictionary<string, PrintQueue> GetPrintQueues(params EnumeratedPrintQueueTypes[] printQueueTypes)
            {
                var server = new PrintServer();
                return server.GetPrintQueues(printQueueTypes).ToDictionary(pq => pq.ShareName != null ? pq.ShareName : pq.Name);
            }
    
            #endregion
    
            #region GetInputBins
    
            /// <summary>
            /// Reads print queue configuration xml to retrieve the current list of input bins.
            /// </summary>
            /// <param name="printQueue">The print queue to query.</param>
            /// <returns></returns>
            public static Dictionary<string, string> GetInputBins(PrintQueue printQueue)
            {
                Dictionary<string, string> inputBins = new Dictionary<string, string>();
    
                // Get the print queue PrintCapabilities.
                XmlDocument xmlDoc = null;
                using (MemoryStream stream = printQueue.GetPrintCapabilitiesAsXml())
                {
                    // Read the JobInputBins out of the PrintCapabilities.
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(stream);
                }
    
                // Create NamespaceManager and add PrintSchemaFrameWork-Namespace (should be on DocumentElement of the PrintTicket).
                // Prefix: psf NameSpace: xmlDoc.DocumentElement.NamespaceURI = "http://schemas.microsoft.com/windows/2003/08/printing/printschemaframework"
                XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
                manager.AddNamespace(xmlDoc.DocumentElement.Prefix, xmlDoc.DocumentElement.NamespaceURI);
    
                // Select all job input bins.
                XmlNodeList nodeList = xmlDoc.SelectNodes("//psf:Feature[@name='psk:JobInputBin']/psf:Option/psf:Property", manager);
    
                // Load the Dictionary with the bin values and names. The names will be used to modify the print ticket if necessary.
                foreach (XmlNode node in nodeList)
                {
                    inputBins.Add(node.LastChild.InnerText, node.ParentNode.Attributes[0].Value);
                }
    
                return inputBins;
            }
    
            #endregion
    
            #region ModifyPrintTicket
    
            /// <summary>
            /// Modifes a print ticket xml after updating a feature value.
            /// 
            /// Sample usage:
            /// Get Dictionary with Inputbins by calling the other method
            /// and get "value" for the desired inputbin you'd like to use...
            /// ...
            /// desiredTray is then something like "NS0000:SurpriseOption7" for example.
            /// defaultPrintTicket is the (Default)PrintTicket you want to modify from the PrintQueue for example
            /// PrintTicket myPrintTicket = WpfPrinterUtils.ModifyPrintTicket(defaultPrintTicket, "psk:JobInputBin", desiredTray);
            /// </summary>
            /// <param name="ticket"></param>
            /// <param name="featureName"></param>
            /// <param name="newValue"></param>
            /// <param name="printQueueName">Optional - If provided, a file is created with the print ticket xml. Useful for debugging.</param>
            /// <param name="folder">Optional - If provided, the path for a file is created with the print ticket xml. Defaults to c:\. Useful for debugging.</param>
            /// <param name="displayMessage">Optional - True to display a dialog with changes. Defaults to false. Useful for debugging.</param>
            /// <returns></returns>
            public static PrintTicket ModifyPrintTicket(PrintTicket ticket, string featureName, string newValue, string printQueueName = null, string folder = null, bool displayMessage = false)
            {
                if (ticket == null)
                {
                    throw new ArgumentNullException("ticket");
                }
    
                // Read Xml of the PrintTicket xml.
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ticket.GetXmlStream());
    
                // Create NamespaceManager and add PrintSchemaFrameWork-Namespace hinzufugen (should be on DocumentElement of the PrintTicket).
                // Prefix: psf NameSpace: xmlDoc.DocumentElement.NamespaceURI = "http://schemas.microsoft.com/windows/2003/08/printing/printschemaframework"
                XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
                manager.AddNamespace(xmlDoc.DocumentElement.Prefix, xmlDoc.DocumentElement.NamespaceURI);
    
                // Search node with desired feature we're looking for and set newValue for it
                string xpath = string.Format("//psf:Feature[@name='{0}']/psf:Option", featureName);
                XmlNode node = xmlDoc.SelectSingleNode(xpath, manager);
                if (node != null)
                {
                    if (node.Attributes["name"].Value != newValue)
                    {
                        if (displayMessage)
                        {
                            System.Windows.MessageBox.Show(string.Format("OldValue: {0}, NewValue: {1}", node.Attributes["name"].Value, newValue), "Input Bin");
                        }
                        node.Attributes["name"].Value = newValue;
                    }
                }
    
                // Create a new PrintTicket out of the XML.
                PrintTicket modifiedPrintTicket = null;
                using (MemoryStream stream = new MemoryStream())
                {
                    xmlDoc.Save(stream);
                    stream.Position = 0;
                    modifiedPrintTicket = new PrintTicket(stream);
                }
    
                // For testing purpose save the print ticket to a file.
                if (!string.IsNullOrWhiteSpace(printQueueName))
                {
                    if (string.IsNullOrWhiteSpace(folder))
                    {
                        folder = "c:\\";
                    }
                    // Colons are not valid in a file name.
                    newValue = newValue.Replace(':', ';');
                    printQueueName = string.Format("{0} PrintTicket {1}.xml", Path.Combine(folder, printQueueName), newValue);
                    if (File.Exists(printQueueName))
                    {
                        File.Delete(printQueueName);
                    }
                    if (!Directory.Exists(Path.GetDirectoryName(printQueueName)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(printQueueName));
                    }
                    using (FileStream stream = new FileStream(printQueueName, FileMode.CreateNew, FileAccess.ReadWrite))
                    {
                        modifiedPrintTicket.GetXmlStream().WriteTo(stream);
                    }
                }
    
                return modifiedPrintTicket;
            }
    
            #endregion
        }
    }
