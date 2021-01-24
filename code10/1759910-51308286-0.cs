    CloudBlobContainer container = new CloudBlobContainer(new Uri(sasUri));
                                CloudBlockBlob blob = container.GetBlockBlobReference(Path.GetFileName(zipFile));
                                // Setup the number of the concurrent operations
                                TransferManager.Configurations.ParallelOperations = 64;
                                                                
                                // Setup the transfer context and track the upoload progress
                                SingleTransferContext context = new SingleTransferContext();
                                context.ProgressHandler = new Progress<TransferStatus>((progress) =>
                                {
                                    int percentage = (int)Math.Round((double)((double)progress.BytesTransferred / (double)zipFileInfo.Length * 100));
                                    //controller.SetProgress(percentage);
                                    controller.SetMessage($"Uploading content {percentage}%");
                                });
                                context.ShouldOverwriteCallbackAsync = new ShouldOverwriteCallbackAsync(ShouldTransferCallback);
                                // Upload a local blob
                                await TransferManager.UploadAsync(
                                    zipFile, blob, null, context, CancellationToken.None);
                      
