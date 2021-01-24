    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    namespace ConsoleAppCore.DAL
    {
        public class BlobStorage
        {
            public static async void UploadContent(CloudBlobContainer containerReference, Stream contentStream, string blobName)
            {
                try
                {
                    using (contentStream)
                    {
                    
                        var blockBlobRef = containerReference.GetBlockBlobReference(blobName);
                        //await containerReference.SetPermissionsAsync(new BlobContainerPermissions
                        //{
                        //    PublicAccess = BlobContainerPublicAccessType.Blob
                        //});
                        await blockBlobRef.UploadFromStreamAsync(contentStream);
                    }
                }
                catch (Exception ex)
                {
                    //Error here
                }
            }
        }
    }
