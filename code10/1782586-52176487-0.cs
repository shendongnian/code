    public async Task<Dictionary<long, string>> IndexDocumentsAsync(TaskSource source, List<RawCaptureEntity> captures, CancellationToken cancellationToken)
    {
        var documents = new List<DocumentAction>();
        var results = new Dictionary<long, string>();
        foreach (var capture in captures) {
            var fields = new Func<RawCaptureEntity,string>[] { rce => rce.Text, rce => rce.IndividualName, rce => rce.EntityName };
            foreach (Func<RawCaptureEntity,string> field in fields) {
                cancellationToken.ThrowIfCancellationRequested();
                var text = TruncateText(CleanseText(field(capture)));
                var entities = await GetEntities(text));
                if ((source.MedWLSSource & 1) == 1) {
                    var documentAction = GetWlsDocumentAction(source, capture, text, entities);
                    if (documentAction == null) {
                        results.Add(capture.CaptureId, $"Status [{(int)capture.Status} - {capture.Status.ToString()}] is not supported for indexing.");
                    } else {
                        documents.Add(documentAction);
                    }
                }
                if ((source.MedWLSSource & 2) == 2) {
                    var documentAction = GetMedDocumentAction(source, capture, text, entities);
                    if (documentAction == null) {
                        if (!results.ContainsKey(capture.CaptureId)) {
                            results.Add(capture.CaptureId, $"Status [{(int)capture.Status} - {capture.Status.ToString()}] is not supported for indexing.");
                        }
                    } else {
                        documents.Add(documentAction);
                    }
                }
            }
        }
        var indexResults = await indexDb.BulkOperationAsync(documents);
        foreach (var result in indexResults) {
            var key = documents[result.Key].Document.CaptureId;
            if (!results.ContainsKey(key)) {
                results.Add(key, result.Value);
            }
        }
        return results;
    }
