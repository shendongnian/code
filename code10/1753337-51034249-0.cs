       private PHAssetCollection FindAlbum(string title)
        {
            PHAssetCollection photoAlbum = null;
            var arguments = new NSObject[] { NSObject.FromObject( title) };
            var fetchOptions = new PHFetchOptions() { Predicate = NSPredicate.FromFormat("title=%@", arguments) };
            PHFetchResult fetchResult = PHAssetCollection.FetchAssetCollections(PHAssetCollectionType.Album, PHAssetCollectionSubtype.AlbumRegular, fetchOptions);
            if (fetchResult.firstObject != null)
            {
                photoAlbum = (PHAssetCollection)fetchResult.firstObject;
               
            }
            return photoAlbum;
        }
