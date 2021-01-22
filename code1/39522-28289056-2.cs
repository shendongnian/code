        public static string PathCombineAndCanonicalize3(string path1, string path2)
        {
            string originalRoot = string.Empty;
            if (Path.IsPathRooted(path1))
            {
                originalRoot = Path.GetPathRoot(path1);
                path1 = path1.Substring(originalRoot.Length);
            }
            string fakeRoot = @"\\thiscantbe\real\";
            string combined = Path.Combine(fakeRoot, path1, path2);
            combined = Path.GetFullPath(combined);
            combined = combined.Substring(fakeRoot.Length);
            combined = Path.Combine(originalRoot, combined);
            return combined;
        }
