    public static void MoveFiles(string source, string destination, LoginInfo loginInfo) {
        try {
            using (SftpClient sftp = new SftpClient(loginInfo.Uri, loginInfo.Port, loginInfo.User, loginInfo.Password)) {
                sftp.Connect();
                var files = sftp.ListDirectory(source)
                foreach (SftpFile file in files) {
                    file.MoveTo(destination + file.Name);
                }
            }
        } catch(Exception ex) {
            //...handle
        }
    }
