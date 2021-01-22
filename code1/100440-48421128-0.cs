        public static IEnumerable<T[]> Permute<T>(T[] array)
        {
            for(int i=0; i<array.Length; i++)
            {
                if (array.Length <= 1)
                {
                    yield return array;
                }
                else
                {
                    T[] except = new T[array.Length - 1];
                    Array.Copy(array, except, i);
                    Array.Copy(array, i + 1, except, i, array.Length - i - 1);
                    foreach (T[] sub in Permute(except))
                    {
                        T[] answer = new T[sub.Length + 1];
                        Array.Copy(sub, 0, answer, 1, sub.Length);
                        answer[0] = array[i];
                        yield return answer;
                    }
                }
            }
        }
