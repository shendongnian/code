    using (var client = new ImapClient ()) {
				client.Connect ("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
				client.Authenticate ("mailo@gmail.com", "password");
                client.Inbox.Open(FolderAccess.ReadWrite);
                var uids = client.Inbox.Search(SearchQuery.NotSeen);
      
                foreach (var uid in uids)
                {
                    var message = client.Inbox.GetMessage(uid);
                    client.Inbox.AddFlags(uid, MessageFlags.Seen, true);
                    foreach (var attachment in message.Attachments.OfType<MimePart>())
                    {
                        if (System.IO.Path.GetExtension(attachment.FileName) == ".xml")
                        {
                            byte[] allBytes = new byte[attachment.Content.Stream.Length];
                            int bytesRead = attachment.Content.Stream.Read(allBytes, 0, (int)attachment.Content.Stream.Length);
                            string texto_definitivo = "";
                            String archivoXML_textoBase64 = "";
                            using (MemoryStream memory = new MemoryStream(allBytes))
                            {
                                StreamReader archivoXML = new StreamReader(memory);
                                archivoXML_textoBase64 = archivoXML.ReadToEnd();
                                byte[] temp_backToBytes = Convert.FromBase64String(archivoXML_textoBase64);
                                texto_definitivo = Encoding.ASCII.GetString(temp_backToBytes);
                                archivoXML.Close();
                                memory.Dispose();
                            }   
                        }      
                    }
                }
				client.Disconnect (true);
			}
