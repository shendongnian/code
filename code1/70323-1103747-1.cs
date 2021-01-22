    var caseNotesTree = from cn in context.tblCaseNotes
                        where cn.PersonID == personID
                        orderby cn.ContactDate
                        select new {
                            cn.CaseNoteID,
                            cn.ContactDate,
                            cn.ParentNote,
                            cn.IsCaseLog,
                            ContactDetailsClip = cn.ContactDetails.Substring(0, Math.Min(cn.ContactDetails.Length, 50))
                        };
