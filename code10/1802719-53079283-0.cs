     int extractFileParentId = pkUniqueId;
            List<ZipExtracFile> extractFileList = lts;
            MsgReader.Outlook.Storage.Message message = new MsgReader.Outlook.Storage.Message(fileNames);
            foreach (var attachment in message.Attachments)
            {
                string fileName = string.Empty;
                pkUniqueId = pkUniqueId + 1;
                if (attachment.GetType() == typeof(MsgReader.Outlook.Storage.Attachment))
                {
                    var attach = (MsgReader.Outlook.Storage.Attachment)attachment;
                    fileName = Path.Combine(tempPath, (attach).FileName);
                    File.WriteAllBytes(fileName, attach.Data);
                    extractFileList.Add(new ZipExtracFile { pkUniqueId = pkUniqueId, fileName = fileName, parentId = extractFileParentId });
                    if(Path.GetExtension(fileName).ToLower() == ".msg")
                    {
                        ExtractMsgFile(fileName, ref pkUniqueId, ref tempPath, lts);
                    }
                }
            }
            message.Dispose();
