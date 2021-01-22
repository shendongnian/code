    public static void Save(IAHeader head) {
        IAHeader orig = new IAHeader();
        if (head.Id == 0) {
            IAData.Entities.IAHeaders.AddObject(head);
        } else {
            orig = IAData.Entities.IAHeaders.Where(h => h.Id == head.Id).FirstOrDefault();
            IAData.Entities.IAHeaders.ApplyCurrentValues(head);
            foreach (IAComment comm in head.Comments.ToList()) {
                if (comm.Id == 0) {
                    comm.IAHeader = null; //disassociate this entity from the parent, otherwise parent will be re-added
                    comm.IAId = head.Id;
                    IAData.Entities.IAComments.AddObject(comm);
                } else {
                    IAComment origComm = orig.Comments.Where(c => c.Id == comm.Id).First();
                    IAData.Entities.IAComments.ApplyCurrentValues(comm);
                }
            }
            foreach (IAAttachment att in head.Attachments.ToList()) {
                if (att.Id == 0) {
                    att.IAHeader = null; //disassociate this entity from the parent, otherwise parent will be re-added
                    att.IAId = head.Id;
                    IAData.Entities.IAAttachments.AddObject(att);
                } else {
                    IAAttachment origAtt = orig.Attachments.Where(a => a.Id == att.Id).First();
                    IAData.Entities.IAAttachments.ApplyCurrentValues(att);
                }
            }
        }
        IAData.Entities.SaveChanges(SaveOptions.DetectChangesBeforeSave | SaveOptions.AcceptAllChangesAfterSave);
    }
