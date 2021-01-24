        private static void DeleteTempFiles()
        {
            string dir = Path.GetDirectoryName(AaTrend.AaTrendLocation);
            foreach (string file in Directory.GetFiles(dir, "aaTrend-*.exe", SearchOption.TopDirectoryOnly))
            {
                File.Delete(file);
            }
        }
