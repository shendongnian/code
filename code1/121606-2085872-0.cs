        private static IEnumerable<string> WalkFiles(string path, string filter)
        {
            var pending = new Queue<string>();
            pending.Enqueue(path);
            string[] tmp;
            while (pending.Count > 0)
            {
                path = pending.Dequeue();
                tmp = Directory.GetFiles(path, filter);
                for(int i = 0 ; i < tmp.Length ; i++) {
                    yield return tmp[i];
                }
                tmp = Directory.GetDirectories(path);
                for (int i = 0; i < tmp.Length; i++) {
                    pending.Enqueue(tmp[i]);
                }
            }
        }
