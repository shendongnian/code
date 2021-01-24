    public class FilesListOptionalParms
        {
            /// Comma-separated list of bodies of items (files/documents) to which the query applies. Supported bodies are 'user', 'domain', 'teamDrive' and 'allTeamDrives'. 'allTeamDrives' must be combined with 'user'; all other values must be used in isolation. Prefer 'user' or 'teamDrive' to 'allTeamDrives' for efficiency.
            public string Corpora { get; set; }  
            /// The source of files to list. Deprecated: use 'corpora' instead.
            public string Corpus { get; set; }  
            /// Whether Team Drive items should be included in results.
            public bool? IncludeTeamDriveItems { get; set; }  
            /// A comma-separated list of sort keys. Valid keys are 'createdTime', 'folder', 'modifiedByMeTime', 'modifiedTime', 'name', 'name_natural', 'quotaBytesUsed', 'recency', 'sharedWithMeTime', 'starred', and 'viewedByMeTime'. Each key sorts ascending by default, but may be reversed with the 'desc' modifier. Example usage: ?orderBy=folder,modifiedTime desc,name. Please note that there is a current limitation for users with approximately one million files in which the requested sort order is ignored.
            public string OrderBy { get; set; }  
            /// The maximum number of files to return per page. Partial or empty result pages are possible even before the end of the files list has been reached.
            public int? PageSize { get; set; }  
            /// The token for continuing a previous list request on the next page. This should be set to the value of 'nextPageToken' from the previous response.
            public string PageToken { get; set; }  
            /// A query for filtering the file results. See the "Search for Files" guide for supported syntax.
            public string Q { get; set; }  
            /// A comma-separated list of spaces to query within the corpus. Supported values are 'drive', 'appDataFolder' and 'photos'.
            public string Spaces { get; set; }  
            /// Whether the requesting application supports Team Drives.
            public bool? SupportsTeamDrives { get; set; }  
            /// ID of Team Drive to search.
            public string TeamDriveId { get; set; }  
        
        }
 
        /// <summary>
        /// Lists or searches files. 
        /// Documentation https://developers.google.com/drive/v3/reference/files/list
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Drive service.</param>  
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>FileListResponse</returns>
        public static FileList List(DriveService service, FilesListOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                // Building the initial request.
                var request = service.Files.List();
                // Applying optional parameters to the request.                
                request = (FilesResource.ListRequest)SampleHelpers.ApplyOptionalParms(request, optional);
                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Files.List failed.", ex);
            }
        }
