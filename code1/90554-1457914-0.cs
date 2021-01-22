    var sourceKeyQuery = from ct in ds.Tables["ChannelTypes"].AsEnumerable()
                         join ch in ds.Tables["Channels"].AsEnumerable()
                         on ct.Field<int>("channelTypeID") equals ch.Field<int>("channelTypeID") into g_ch
                         join sk in ds.Tables["SourceKeys"].AsEnumerable()
                         on ct.Field<int>("channelTypeID") equals sk.Field<int>("channelID") into g_ct
                         from ch in g_ch.DefaultIfEmpty()
                         from sk in g_ct.DefaultIfEmpty()
                         select new 
                         {
                             channelTypeID = ct.Field<int>("channelTypeID"),
                             channelType = ct.Field<string>("channelType"),
                             channelID = (ch == null)?null:ch.Field<int?>("channelID"),
                             channel = (ch == null)?String.Empty:ch.Field<string>("channel"),
                             sourceKeyID = (sk == null)?null:sk.Field<int?>("sourceKeyID"),
                             sourceKey = (sk == null)?String.Empty:sk.Field<string>("sourceKey")
                         };
