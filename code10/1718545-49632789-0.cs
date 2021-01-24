    var objects = from song in allSongs
                  let isFavourite = bob.FavouriteSongs.Contains( song )
                  let isHated = bob.HatedSongs.Contains( song )
                  select (
                      Artist = song.Artist,
                      Name = song.Name,
                      IsFavourite = isFavourite,
                      IsHated = isHated,
                      IsNeutral = !isFavourite && !isHated
                  );
