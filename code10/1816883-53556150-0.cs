    public Artist GetSingleWithDetails(int artistId)
        {
           return = Context.Set<Artist>().Include(a => a.ArtistDetails).FirstOrDefault(x => x.ArtistId == artistId);
           
        }
