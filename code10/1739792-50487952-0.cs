    var result = Documents.Where(d => d.ID == 1 && d.StatusID != -1)
                          .GroupJoin(Attachments, d => d.ID, a => a.DocumentID,
                          (d, matchedAttachments) =>
                          {
                              //here you can do whatever with document and list of corresponding matched attachments
                              return matchedAttachments.DefaultIfEmpty().Select(ma => new Result { ID = d.ID, AttachID = ma?.ID });
                          });
