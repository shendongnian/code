    using (Ftp client = new Ftp())
            {
                // connect and login to the FTP site
                client.Connect("mirror.aarnet.edu.au");
                client.Login("anonymous", "my@password");
                // download all files
                client.GetFiles(
                    "/pub/fedora/linux/development/i386/os/EFI/*",
                    "c:\\temp\\download",
                    FtpBatchTransferOptions.Recursive,
                    FtpActionOnExistingFiles.OverwriteAll
                );
                client.Disconnect();
            }
