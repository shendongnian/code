        //My base class
        [ProtoContract]
        public class grid
        {
            [ProtoMember(1), CategoryAttribute("Grid Settings"), DescriptionAttribute("Number of Horizontal GRID Segments.")]
            public int HorizontalCells { get; set; }
        
            //more properties
        }
        //Our Protostub ... Originally, just for Stackoverflow.  But, I'm liking the name.
        [ProtoContract]
        [ProtoInclude(7, typeof(SKA_Segments))]
        public class ProtoStub : grid
        {
        }
        SKA_Segments seg_map;
        [ProtoContract]
        public class SKA_Segments : ProtoStub
        {
            public SKA_Segments()
            {
            }
            public override void Draw(Graphics Graf, Pen pencil)
            {
                base.Draw(Graf, pencil);
            }
        }
        //Serialization stuff
        seg_map.HorizontalCells = 1000;  //test property comes from the grid class
        //Need to stream all three of these into the one file
        //Serializer.SerializeWithLengthPrefix(stream, map, PrefixStyle.Base128, 1);
        //Serializer.SerializeWithLengthPrefix(stream, col_map, PrefixStyle.Base128, 1);
        Serializer.SerializeWithLengthPrefix(stream, seg_map, PrefixStyle.Base128, 1);
        //De-Serialization stuff
        //map = Serializer.DeserializeWithLengthPrefix<SKA_MAP>(stream, PrefixStyle.Base128, 1);
        //col_map = Serializer.DeserializeWithLengthPrefix<SKA_Collision>(stream, PrefixStyle.Base128, 1);
        seg_map = Serializer.DeserializeWithLengthPrefix<SKA_Segments>(stream, PrefixStyle.Base128, 1);
