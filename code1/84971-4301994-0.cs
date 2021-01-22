        /// <summary>
        /// 添加压缩文件 p 为客户端传回来的文件/夹列表,用分号隔开，不包括主路径， zipfile压缩包的名称
        /// </summary>
        /// <param name="p"></param>
        /// <param name="zipfile"></param>
        public void AddZipFile(string p, string zipfile)
        {
            if (ServerDir.LastIndexOf(@"\") != ServerDir.Length - 1)
            {
                ServerDir += @"\";
            }
            string[] tmp = p.Split(new char[] { ';' }); //分离文件列表
            if (zipfile != "") //压缩包名称不为空
            {
                string zipfilepath=ServerDir + zipfile;
                if (_ZipOutputStream == null)
                {
                    _ZipOutputStream = new ZipOutputStream(File.Create(zipfilepath));
                }
                for (int i = 0; i < tmp.Length; i++)
                {
                    if (tmp[i] != "") //分离出来的文件名不为空
                    {
                        this.AddZipEntry(tmp[i], _ZipOutputStream, out _ZipOutputStream); //向压缩文件流加入内容
                    }
                }
            }
        }
        private static ZipOutputStream _ZipOutputStream;
        public void Close()
        {
            _ZipOutputStream.Finish();
            _ZipOutputStream.Close();
        }
