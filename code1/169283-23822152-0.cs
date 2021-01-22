    [ProtoContract]
    public class MyOption
    {
        [ProtoMember(2)]
        public View m_printListView = View.Details;   (A)
        [ProtoMember(5) ]
        public bool m_bool = true ;                   (B)
    }
    
    void Main()
    {
        string fname = @"D:/test.dat";
        if (File.Exists(fname) )
        {
            File.Delete(fname);
        }
        using(FileStream fs=  new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Write) )
        {
            MyOption opt = new MyOption();
            opt.m_printListView = View.LargeIcon; // (1)
            opt.m_bool = false;                   // (2)
            
            Serializer.SerializeWithLengthPrefix(fs, opt, PrefixStyle.Fixed32);
        }
        using(FileStream fs=  new FileStream(@"D:/test.dat", FileMode.Open, FileAccess.Read) )
        {
            MyOption opt;
            opt = Serializer.DeserializeWithLengthPrefix<MyOption>(fs, PrefixStyle.Fixed32);
            Console.WriteLine(opt.m_printListView);
            Console.WriteLine(opt.m_bool);
        }
    }
    
