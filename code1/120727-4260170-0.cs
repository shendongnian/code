          DirectoryObject : IDisposable (Important!)
              ctor (DirectoryEntry)
              ctor (SearchResult)
              ctor (string Path)
              string Path
              bool IsValid 
              Search(with a gazillion overloads)
              DirectoryObjectPropertyCollection Properties 
              //(which itself uses DirectoryObjectPropertyValueCollection to wrap PropertyValueCollection)
          //To get at the native underlying objects if necessary since I only wrapped commonly used elements
          DirectoryEntry NativeDirectoryEntry  
          SearchResult NativeSearchResult
          
          //So I know whether to grab the native SearchResult or DirectoryEntry
          IsDirectoryEntry
          IsSearchResult
