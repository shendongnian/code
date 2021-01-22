    	private void ConvertAndSend(string emailTo,Uri url)
		{
			try
			{
				string mimeType;
				string charset;
				if (NetworkUtils.UrlExists(url.AbsoluteUri,out mimeType,out charset))
				{
					if (mimeType.Equals("text/html",StringComparison.OrdinalIgnoreCase))
						SendUrlToEmail(url.AbsoluteUri,emailTo,charset);
					else
					{
						string fileName = Path.GetFileName(url.AbsoluteUri);
						string extension = GetExtensionByMimeType(mimeType);
						if (String.IsNullOrEmpty(fileName)
							|| fileName.Length > 200)
							fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
						if (!Path.GetExtension(fileName).Equals(extension
							,StringComparison.OrdinalIgnoreCase))
							fileName += extension;
						string tempFolder = Path.Combine(Server.MapPath("App_Data")
							,"TempFiles");
						if (!Directory.Exists(tempFolder))
							Directory.CreateDirectory(tempFolder);
						fileName = Path.Combine(tempFolder,fileName);
						new WebClient().DownloadFile(url.AbsoluteUri,fileName);
						SendMessage(emailTo,url.AbsoluteUri,Path.GetFileName(fileName),fileName);
					}
				}
				else
				{
					throw new WebException("Requiested address is not available at the moment.");
				}
			}
			catch (Exception ex)
			{
				SendMessage(emailTo,url.AbsoluteUri,ex.Message,null);
			}
		}
		public void SendUrlToEmail(string url
			,string emailTo
			,string charset)
		{
			Encoding encFrom;
			try { encFrom = Encoding.GetEncoding(charset); }
			catch { encFrom = Encoding.UTF8; }
			CDO.Message msg = null;
			ADODB.Stream stm = null;
			try
			{
				msg = new CDO.MessageClass();
				msg.MimeFormatted = true;
				msg.CreateMHTMLBody(url
					,CDO.CdoMHTMLFlags.cdoSuppressNone
					,string.Empty
					,string.Empty);
				//msg.HTMLBodyPart.Fields["urn:schemas:mailheader:Content-Language"].Value = "ru";
				msg.HTMLBodyPart.Fields["urn:schemas:mailheader:charset"].Value = "Cp" + encFrom.CodePage;
				msg.HTMLBodyPart.Fields["urn:schemas:mailheader:content-type"].Value = "text/html; charset=" + charset;
				msg.HTMLBodyPart.Fields.Update();
				msg.HTMLBody = documentBody;
				msg.Subject = url;
				msg.From = Params.Username;
				msg.To = emailTo;
				msg.Configuration.Fields[GmailMessage.SMTP_SERVER].Value = SmtpServer;
				msg.Configuration.Fields[GmailMessage.SEND_USING].Value = 2;
				msg.Configuration.Fields.Update();
				msg.Send();
			}
			finally
			{
				if (stm != null)
				{
					stm.Close();
					Marshal.ReleaseComObject(stm);
				}
				if (msg != null)
					Marshal.ReleaseComObject(msg);
			}
		}
