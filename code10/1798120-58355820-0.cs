        private static void forEachCell(int size, Action<int, int> action)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    action(j, i);
                }
            }
        }
