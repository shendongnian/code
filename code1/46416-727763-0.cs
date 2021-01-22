        public void RecurseTest(DirectoryInfo dirInfo, 
                                StringBuilder sb, 
                                int depth)
        {
            _dirCounter++;
            if (depth > _maxDepth)
                _maxDepth = depth;
            var array = dirInfo.GetFileSystemInfos();
            foreach (var item in array)
            {
                sb.Append(item.FullName);
                if (item is DirectoryInfo)
                {
                    sb.Append(" (D)");
                    sb.AppendLine();
                    RecurseTest(item as DirectoryInfo, sb, depth+1);
                }
                else
                { _fileCounter++; }
                sb.AppendLine();
            }
        }
