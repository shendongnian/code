    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Touching {
        class CharFinder {
        
            public static List<Tuple<int, int>> counted = new List<Tuple<int, int>>();
            public static void Main(string[] args) {
                getInputs(out char target, out char indexed, out List<string> lines);
                List<Tuple<int, int>> indexes = new List<Tuple<int, int>>();
                for (int i = 0; i != lines.Count; i++) {
                    for (int j = 0; j != lines[i].Length; j++) {
                        if (lines[i][j] == indexed) {
                            indexes.Add(new Tuple<int, int>(i, j));
                        }
                    }
                } int tCount = countNeighbor(lines, indexes[0], target);
                for (int i = 0; i != indexes.Count; i++) {
                    tCount += countNeighbor(lines, indexes[i], target);
                } Console.WriteLine(tCount.ToString()); 
                Console.ReadLine();
            }
            public static int countNeighbor(List<string> grid, Tuple<int, int> ind, char target) {
                int count = 0;
                for (int i = ind.Item1 - 1; i < ind.Item1 + 2; i++) {
                    if (i == -1 || i >= grid.Count) { continue; } 
                    for (int j = ind.Item2 - 1; j < ind.Item2 + 2; j++) {
                        if (j == -1 || j >= grid[i].Length) { continue; }
                        if (grid[i][j] == target && !counted.Contains(new Tuple<int, int>(i, j))) { 
                            counted.Add(new Tuple<int, int>(i, j));
                            count++; 
                        }
                    }
                } return count;
            }
            public static void getInputs(out char target, out char indexed, out List<string> strs) {
                int lines = 0;
                strs = new List<string>();
                while (true) {
                    Console.Clear();
                    Console.Write("Number of lines?: ");
                    try { lines = Convert.ToInt32(Console.ReadLine()); if (lines < 1) { throw new Exception(); } break; }
                    catch { Console.WriteLine("ERROR: Must be a positive integer."); Console.ReadLine(); }
                } Console.Clear();
                Console.Write("Target?: ");
                target = Console.ReadLine()[0];
                Console.Clear();
                Console.Write("Indexed?: ");
                indexed = Console.ReadLine()[0];
                for (int i = 0; i < lines; i++) {
                    strs.Add(Console.ReadLine());
                }
            }
        }
    }
