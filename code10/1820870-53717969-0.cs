      using (var context = new BSoftWEDIIContext())
                    {
                        foreach (var senderId in senderIdList)
                        {
                            var ediDocuments = context.EDIDocuments.SqlQuery("Update EDIDocument SET IsIgnored=1 from EDIDocument edi  inner JOIN  FileDetails files on edi.FileDetailsId = files.Id where edi.IsDeleted = 0 and edi.SenderID=@senderId and edi.DocumentTypeID != 3 and edi.DocumentTypeID != 5 and edi.DocumentTypeID != 2 and edi.IsIgnored = 0 and files.IsDeleted = 0",
                                new SqlParameter
                                {
                                    ParameterName = "senderId",
                                    DbType = DbType.Int32,
                                    Value = senderId
                                });
                        }
                    }
