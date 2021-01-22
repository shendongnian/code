        /// <summary>
        ///  
        /// Converts a version string in the format of 
        /// [major].[minor].[build].[revision] into an integer.
        ///  
        /// </summary>
        /// <remarks>
        /// Each part of the build number must be within the range of 0 to 255.
        /// </remarks>
        /// <param name="version"> The version to convert to an integer. </param>
        /// <returns>
        /// The integer representation of the <paramref name="version"/>.
        /// </returns>
        public static int VersionToInt( string version ) {
            // Parse version number
            var versionParts = version.Split( '.' );
            if ( versionParts.Length != 4 ) {
                throw new ArgumentException( "Invalid version number; invalid number of version parts, expected 4 (major.minor.build.revision)",
                                             "version" );
            }
            // Convert parts to bytes
            byte major, minor, build, revision;
            if ( !byte.TryParse( versionParts[0], out major ) ) {
                throw new ArgumentException( "Invalid version number; invalid major number", 
                                             "version" );
            }
            if ( !byte.TryParse( versionParts[1], out minor ) ) {
                throw new ArgumentException( "Invalid version number; invalid minor number",
                                             "version" );
            }
            if ( !byte.TryParse( versionParts[2], out build ) ) {
                throw new ArgumentException( "Invalid version number; invalid build number", 
                                             "version" );
            }
            if ( !byte.TryParse( versionParts[3], out revision ) ) {
                throw new ArgumentException( "Invalid version number; invalid revision number", 
                                             "version" );
            }
            // Combine bytes into an integer
            var versionInteger = 0;
            versionInteger |= major << 24;
            versionInteger |= minor << 16;
            versionInteger |= build << 8;
            versionInteger |= revision;
            return versionInteger;
        }
