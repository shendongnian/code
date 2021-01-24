    public static void CopyBlobs(
                CloudBlobContainer srcContainer,  
                string policyId, 
                CloudBlobContainer destContainer)
    {
        // get the SAS token to use for all blobs
        string blobToken = srcContainer.GetSharedAccessSignature(
                       new SharedAccessBlobPolicy(), policyId);
 
     
        var srcBlobList = srcContainer.ListBlobs(true, BlobListingDetails.None);
        foreach (var src in srcBlobList)
        {
            var srcBlob = src as CloudBlob;
 
            // Create appropriate destination blob type to match the source blob
            CloudBlob destBlob;
            if (srcBlob.Properties.BlobType == BlobType.BlockBlob)
            {
                destBlob = destContainer.GetBlockBlobReference(srcBlob.Name);
            }
            else
            {
                destBlob = destContainer.GetPageBlobReference(srcBlob.Name);
            }
 
            // copy using src blob as SAS
            destBlob.StartCopyFromBlob(new Uri(srcBlob.Uri.AbsoluteUri + blobToken));
        }
    }
