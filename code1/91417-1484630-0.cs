            public void ReadWLPGRegions(string sourceFile)
        {
            string microsoftRegions = @"/xmp/RegionInfo/Regions";
            string microsoftPersonDisplayName = @"/PersonDisplayName";
            string microsoftRectangle = @"/Rectangle";
            BitmapCreateOptions createOptions = BitmapCreateOptions.PreservePixelFormat | BitmapCreateOptions.IgnoreColorProfile;
            using (Stream sourceStream = File.Open(sourceFile, FileMode.Open, FileAccess.Read))
            {
                BitmapDecoder sourceDecoder = BitmapDecoder.Create(sourceStream, createOptions, BitmapCacheOption.None);
                // Check source has valid frames
                if (sourceDecoder.Frames[0] != null && sourceDecoder.Frames[0].Metadata != null)
                {
                    BitmapMetadata sourceMetadata = sourceDecoder.Frames[0].Metadata as BitmapMetadata;
                    // Check there is a RegionInfo
                    if (sourceMetadata.ContainsQuery(microsoftRegions))
                    {
                        BitmapMetadata regionsMetadata = sourceMetadata.GetQuery(microsoftRegions) as BitmapMetadata;
                        // Loop through each Region
                        foreach (string regionQuery in regionsMetadata)
                        {
                            string regionFullQuery = microsoftRegions + regionQuery;
                            // Query for all the data for this region
                            BitmapMetadata regionMetadata = sourceMetadata.GetQuery(regionFullQuery) as BitmapMetadata;
                            if (regionMetadata != null)
                            {
                                if (regionMetadata.ContainsQuery(microsoftPersonDisplayName) &&
                                    regionMetadata.ContainsQuery(microsoftRectangle))
                                {
                                    Console.Writeline( regionMetadata.GetQuery(microsoftRectangle).ToString()));
                                     Console.WriteLine(regionMetadata.GetQuery(microsoftPersonDisplayName).ToString()));
                                }
                            }
                        }
                    }
                }
            }
        }
