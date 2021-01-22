        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        /// <summary>
        /// Use to emulate the C lib function _splitpath()
        /// </summary>
        /// <param name="path">The path to split</param>
        /// <param name="rootpath">optional root if a relative path</param>
        /// <returns>the folders in the path. 
        ///     Item 0 is drive letter with ':' 
        ///     If path is UNC path then item 0 is "\\"
        /// </returns>
        /// <example>
        /// string p1 = @"c:\p1\p2\p3\p4";
        /// string[] ap1 = p1.SplitPath();
        /// // ap1 = {"c:", "p1", "p2", "p3", "p4"}
        /// string p2 = @"\\server\p2\p3\p4";
        /// string[] ap2 = p2.SplitPath();
        /// // ap2 = {@"\\", "server", "p2", "p3", "p4"}
        /// string p3 = @"..\p3\p4";
        /// string root3 = @"c:\p1\p2\";
        /// string[] ap3 = p1.SplitPath(root3);
        /// // ap3 = {"c:", "p1", "p3", "p4"}
        /// </example>
        public static string[] SplitPath(this string path, string rootpath = "")
        {
            string drive;
            string[] astr;
            path = Path.GetFullPath(Path.Combine(rootpath, path));
            if (path[1] == ':')
            {
                drive = path.Substring(0, 2);
                string newpath = path.Substring(2);
                astr = newpath.Split(new[] { Path.DirectorySeparatorChar }
                    , StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                drive = @"\\";
                astr = path.Split(new[] { Path.DirectorySeparatorChar }
                    , StringSplitOptions.RemoveEmptyEntries);
            }
            string[] splitPath = new string[astr.Length + 1];
            splitPath[0] = drive;
            astr.CopyTo(splitPath, 1);
            return splitPath;
        }
