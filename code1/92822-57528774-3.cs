        private List<int> ReadListenerIds()
        {
            int numMembers;
            int[] memberIds;
            int position = 0;
            using( var view = this.registrations.CreateViewAccessor() )
            {
                numMembers = view.ReadInt32( position );
                position += 4;
                memberIds = new int[numMembers];
                view.ReadArray( position, memberIds, 0, numMembers );
                position += sizeof( int ) * numMembers;
            }
            return new List<int>( memberIds );
        }
        private void WriteListenerIds( List<int> listenerIds )
        {
            int position = 0;
            using( var view = this.registrations.CreateViewAccessor() )
            {
                view.Write( position, (int)listenerIds.Count );
                position += 4;
                foreach( int id in listenerIds )
                {
                    view.Write( position, (int)id );
                    position += 4;
                }
            }
        }
