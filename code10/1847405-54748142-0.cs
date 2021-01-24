        class Item
        {
            public Item( Int32 id, String name, String family, String des )
            {
                this.Id     = id;
                this.Name   = name;
                this.Family = family;
                this.Des    = des;
            } 
            public Int32  Id     { get; }
            public String Name   { get; }
            public String Family { get; }
            public String Des    { get; }
        }
