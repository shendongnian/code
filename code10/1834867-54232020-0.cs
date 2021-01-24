    using (var context = new BSoftWEDIIContext())
                {
    
                    if (!string.IsNullOrEmpty(controlNumber))
                    {
                        controlNumber = controlNumber;
                    }
                    if (!string.IsNullOrEmpty(senderNumber))
                    {
                        senderNumber = senderNumber;
                    }
    
                    var fileDetail = context.FileDetails.SqlQuery("select * from FileDetails where " + controlNumber.ToString() + " is not null" + " OR CONVERT(varchar(max), RawData) like '%" + controlNumber.ToString() + "%' AND CONVERT(varchar(max), RawData) like '%" + senderNumber.ToString() + "%'").ToList();
                    matchedFileId = fileDetail?.Select(a => a.Id).ToList();
                }
