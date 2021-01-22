            FtpWebRequest _fwr = FtpWebRequest.Create(uri) as FtpWebRequest     
            _fwr.Credentials = cred;
            _fwr.UseBinary = true;
            _fwr.UsePassive = true;
            _fwr.KeepAlive = true;
            _fwr.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            StreamReader _sr = new StreamReader(_fwr.GetResponse().GetResponseStream());
            List<object> _dirlist = new List<object>();
            List<object> _attlist = new List<object>();
            List<object> _datelist = new List<object>();
            List<long> _szlist = new List<long>();
            while (!_sr.EndOfStream)
            {
                string[] buf = _sr.ReadLine().Split(' ');
                //string Att, Dir;
                int numcnt = 0, offset = 4; ;
                long sz = 0;
                for (int i = 0; i < buf.Length; i++)
                {
                    //Count the number value markers, first before the ftp markers and second
                    //the file size.
                    if (long.TryParse(buf[i], out sz)) numcnt++;
                    if (numcnt == 2)
                    {
                        //Get the attribute
                        string cbuf = "", dbuf = "", abuf = "";
                        if (buf[0][0] == 'd') abuf = "Dir"; else abuf = "File";
                        //Get the Date
                        if (!buf[i+3].Contains(':')) offset++;
                        for (int j = i + 1; j < i + offset; j++)
                        {
                            dbuf += buf[j];
                            if (j < buf.Length - 1) dbuf += " ";
                        }
                        //Get the File/Dir name
                        for (int j = i + offset; j < buf.Length; j++)
                        {
                            cbuf += buf[j];
                            if (j < buf.Length - 1) cbuf += " ";
                        }
                        //Store to a list.
                        _dirlist.Add(cbuf);
                        _attlist.Add(abuf);
                        _datelist.Add(dbuf);
                        _szlist.Add(sz);
                        offset = 0;
                        break;
                    }
                }
            }
