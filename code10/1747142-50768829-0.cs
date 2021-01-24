    private void RetrieveDocuments(DocumentIdentifier[] identifiers, List<FileHostResult> results)
    {
        results.AddRange(identifiers.AsParallel().Select(x => RetrieveDocument(x)));
    }
    
    private FileHostResult RetrieveDocument(DocumentIdentifier x)
    {
        return GetFileHostResultFromFileHost(x.ExternalIdentifier);
    }
