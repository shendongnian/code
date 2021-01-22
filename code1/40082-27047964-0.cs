           enum GroupTypes
            {
                Unknown = 0,
                OEM = 1,
                CMB = 2
            }
            static GroupTypes StrToEnum(string str)
            {
                GroupTypes g = GroupTypes.Unknown;
                try
                {
                    object o = Enum.Parse(typeof(GroupTypes), str, true);
                    g = (GroupTypes)(o ?? 0);
                }
                catch
                {
                }
                return g;
            }
    // then use it like this
    GroupTypes g = StrToEnum("OEM");
    GroupTypes g = StrToEnum("bad value");
