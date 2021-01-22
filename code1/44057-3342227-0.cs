    public static long GetRevision(String target)
        {
            SvnClient client = new SvnClient();
            //SvnInfoEventArgs info;
            //client.GetInfo(SvnTarget.FromString(target), out info); //Specify the repository root as Uri
            //return info.Revision
            //return info.LastChangeRevision
            Collection<SvnLogEventArgs> info = new Collection<SvnLogEventArgs>();
            client.GetLog(target, out info);
            return info[0].Revision;
        }
