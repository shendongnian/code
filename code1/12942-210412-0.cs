     Collection<StepDoc> docstoDelete = new Collection<StepDoc>();
    foreach (StepDoc oldDoc in OldDocs)
                        {
                            bool delete = false;
                            foreach (StepDoc newDoc in NewDocs)
                            {
                                if (newDoc.DocId == oldDoc.DocId)
                                {
                                    delete = true;
                                }
                            }
                            if (delete) docstoDelete.Add(oldDoc);
                        }
                        foreach (StepDoc doc in docstoDelete)
                        {
                            OldDocs.Remove(doc);
                            NewDocs.Remove(doc);
                        }
