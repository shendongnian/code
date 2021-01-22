    var AttachmentsPathElement = (from e in mySettings.Descendants("AttachmentsPath")
                                   select e).SingleOrDefault();
                
                if(AttachmentsPathElement != null)
                {
                    AttachmentsPath = AttachmentsPathElement.Value;
                }
