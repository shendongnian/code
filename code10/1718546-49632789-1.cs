    var objects = from song in allSongs
                  let isFavourite = bob.FavouriteSongs.Contains( song )
                  let isHated = bob.HatedSongs.Contains( song )
                  select (
                      song.Artist,
                      song.Name,
                      isFavourite,
                      isHated,
                      IsNeutral : !isFavourite && !isHated
                  );
