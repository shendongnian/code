        [DllImport("kernel32.dll")]
        private static extern uint QueryDosDevice(string lpDeviceName, StringBuilder lpTargetPath, int ucchMax);
        private static string GetPhysicalPath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }
            // Get the drive letter
            var pathRoot = Path.GetPathRoot(path);
            if (string.IsNullOrEmpty(pathRoot))
            {
                throw new ArgumentNullException("path");
            }
            var substPrefix = @"\??\";
            var lpDeviceName = pathRoot.Replace(@"\", string.Empty);            
            var lpTargetPath = new StringBuilder(260);
            if (QueryDosDevice(lpDeviceName, lpTargetPath, lpTargetPath.Capacity) != 0)
            {
                string result;
                // If drive is substed, the result will be in the format of "\??\C:\RealPath\".
                if (lpTargetPath.ToString().StartsWith(substPrefix))
                {
                    // Strip the \??\ prefix.
                    var root = lpTargetPath.ToString().Remove(0, substPrefix.Length);
                    result = Path.Combine(root, path.Replace(Path.GetPathRoot(path), string.Empty));
                }
                else
                {
                    // if not SUBSTed, just assume it's not mapped.
                    result = path;
                }
                return result;
            }
            else
            {
                return null;
            }
        }
