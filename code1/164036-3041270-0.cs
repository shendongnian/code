    using System.Collections.Generic;
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] vec0 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int[] vec1 = { 1, 4, 2, 7, 3, 2 };
                int[] vec2 = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int[] vec3 = { 7, 2, 7, 9, 9, 6, 1, 0, 4 };
                int[] vec4 = { 0, 0, 0, 0, 0, 0 };
                List<int> temp = new List<int>();
                temp.AddRange(vec0);
                temp.AddRange(vec1);
                temp.AddRange(vec2);
                temp.AddRange(vec3);
                temp.AddRange(vec4);
                int[] mainvec = temp.ToArray();
            }
        }
    }
