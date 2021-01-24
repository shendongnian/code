    private static void HandleIncomingAttachment(IMessageActivity activity, IMessageActivity reply)
            {
                foreach (var file in activity.Attachments)
                {
                    // Determine where the file is hosted.
                    var remoteFileUrl = file.ContentUrl;
    
                    // Save the attachment to the system temp directory.
                    var localFileName = Path.Combine(Path.GetTempPath(), file.Name);
    
                    // Download the actual attachment
                    using (var webClient = new WebClient())
                    {
                        webClient.DownloadFile(remoteFileUrl, localFileName);
                    }
    
                    reply.Text = $"Attachment \"{activity.Attachments[0].Name}\"" +
                                 $" has been received and saved to \"{localFileName}\"";
                }
            }
