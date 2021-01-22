        public static bool IsSame(this DirectoryInfo that, DirectoryInfo other)
        {
            // zip extension wouldn't work here because it truncates the longer 
            // enumerable, resulting in false positive
            var e1 = that.EnumeratePathDirectories().GetEnumerator();
            var e2 = other.EnumeratePathDirectories().GetEnumerator();
            
            while (true)
            {
                var m1 = e1.MoveNext();
                var m2 = e2.MoveNext();
                if (m1 != m2) return false; // not same length
                if (!m1) return true; // finished enumerating with no differences found
                if (!e1.Current.Name.Equals(e2.Current.Name, StringComparison.InvariantCultureIgnoreCase))
                    return false; // current folder in paths differ
            }
        }
        public static IEnumerable<DirectoryInfo> EnumeratePathDirectories(this DirectoryInfo di)
        {
            var stack = new Stack<DirectoryInfo>();
            DirectoryInfo current = di;
            while (current != null)
            {
                stack.Push(current);
                current = current.Parent;
            }
            return stack;
        }
        // irrelevant for this question, but still useful:
        public static IEnumerable<DirectoryInfo> EnumeratePathDirectories(this FileInfo fi)
        {
            return fi.Directory.EnumeratePathDirectories();
        }
        public static bool StartsWith(this FileInfo fi, DirectoryInfo directory)
        {
            return fi.Directory.StartsWith(directory);
        }
        public static bool StartsWith(this DirectoryInfo di, DirectoryInfo directory)
        {
            return di.EnumeratePathDirectories().Any(d => d.IsSame(directory));
        }
