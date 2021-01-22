    class MyMapper
    {
        delegate DestEnum singlemap(SourceEnum);
        static Dictionary<SourceEnum, singlemap> _source2dest = 
           new Dictionary<SourceEnum, singlemap>();
        static MyMapper()
        {
             //place there non-default conversion
             _source2dest[S_xxxx] = My_delegate_to_cast_S_xxxx;
             ......
        }
        static singlemap MapDelegate(SourceEnum se)
        {
            singlemap retval;
            //checking has complexity O(1)
            if(_source2dest.TryGetValue ( se, out retval) )
                return retval;
            return default_delegate;
        }
