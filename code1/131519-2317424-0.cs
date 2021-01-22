     var result = from ddr in db.E_DesignDocumentRevisions
                             group ddr by new
                                              {
                                                  ddr.DesignDocumentID,
                                                  ddr.E_DesignDocument.DocumentNumber
                                              }
                             into g
                             select new
                                        {
                                            MaxRevision = g.Max(x => x.Revision),
                                            g.Key.DesignDocumentID,
                                            g.Key.DocumentNumber
                                        };
