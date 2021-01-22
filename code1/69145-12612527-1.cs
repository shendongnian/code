            uint error = EDSDK.EDS_ERR_OK;
            IntPtr stream = IntPtr.Zero;
            EDSDK.EdsDirectoryItemInfo directoryItemInfo;
            error = EDSDK.EdsGetDirectoryItemInfo(this.DirectoryItem, out directoryItemInfo);
            //create a file stream to accept the image
            if (error == EDSDK.EDS_ERR_OK)
            {
                error = EDSDK.EdsCreateMemoryStream(directoryItemInfo.Size, out stream);
            }
            //down load image
            if (error == EDSDK.EDS_ERR_OK)
            {
                error = EDSDK.EdsDownload(this.DirectoryItem, directoryItemInfo.Size, stream);
            }
            //complete download
            if (error == EDSDK.EDS_ERR_OK)
            {
                error = EDSDK.EdsDownloadComplete(this.DirectoryItem);
            }
            //convert to memory stream
            IntPtr pointer; //pointer to image stream
            EDSDK.EdsGetPointer(stream, out pointer);
            uint length = 0;
            EDSDK.EdsGetLength(stream, out length);
            byte[] bytes = new byte[length];
            //Move from unmanaged to managed code.
            Marshal.Copy(pointer, bytes, 0, bytes.Length);
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(bytes);
            Image image = System.Drawing.Image.FromStream(memoryStream);
            if (pointer != IntPtr.Zero)
            {
                EDSDK.EdsRelease(pointer);
                pointer = IntPtr.Zero;
            }
            if (this.DirectoryItem != IntPtr.Zero)
            {
                EDSDK.EdsRelease(this.DirectoryItem);
                this.DirectoryItem = IntPtr.Zero;
            }
            if (stream != IntPtr.Zero)
            {
                EDSDK.EdsRelease(stream);
                stream = IntPtr.Zero;
            }
